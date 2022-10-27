using ETicaretAPI.Application.Repositories.ProductRepo;
using ETicaretAPI.Application.Services.Storages;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ETicaretAPI.Application.Features.Commands.ProductImages.UploadProductImage
{
    public class UploadPhotoImageCommandHandler : IRequestHandler<UploadPhotoImageCommandRequest, UploadPhotoImageCommandResponse>
    {
        private readonly IStorageService _storageService;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public UploadPhotoImageCommandHandler(IStorageService storageService, IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _storageService = storageService;
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        public async Task<UploadPhotoImageCommandResponse> Handle(UploadPhotoImageCommandRequest request, CancellationToken cancellationToken)
        {
            var datas = await _storageService.UploadAsync("product-images", request.Files);
            Domain.Entities.Product p = await _productReadRepository.GetByIdAsync(request.Id);

            //dataları dön
            foreach (var r in datas)
            {
                //parametreden gelen product ile resimleri eşleştirebilmek için veritabanından ilgili product nesnesini çek
                p.ProductImages.Add(new Domain.Entities.ProductImages()
                {
                    //123.png
                    FileName = r.fileName,
                    //product-images
                    FilePath = r.path,
                    //p
                    Products = new List<Domain.Entities.Product>() { p },
                    StorageName = _storageService.StorageName
                });
                //Bu nesneye filename,path i ver bu nesnenin product
            }
            //await _fileWriteRepository.AddRangeAsync(datas.Select(d=> new File() {FileName=d.fileName,FilePath = d.path,StorageName=_storageService.StorageName}).ToList());
            try
            {
                await _productWriteRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return new()
            {
                IsSuccess = true
            };
        }
    }
}
