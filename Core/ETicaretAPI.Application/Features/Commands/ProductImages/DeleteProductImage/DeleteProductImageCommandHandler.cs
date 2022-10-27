using ETicaretAPI.Application.Repositories.ProductRepo;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace ETicaretAPI.Application.Features.Commands.ProductImages.DeleteProductImage
{
    public class DeleteProductImageCommandHandler : IRequestHandler<DeleteProductImageCommandRequest, DeleteProductImageCommandResponse>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public DeleteProductImageCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        public async Task<DeleteProductImageCommandResponse> Handle(DeleteProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            //route tan gelen id ye ait product ı elde edelim
            Domain.Entities.Product? product = await _productReadRepository.Table.Include(p => p.ProductImages).FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));
            if (product != null)
            {
                Domain.Entities.ProductImages? productImages = product.ProductImages.FirstOrDefault(pi => pi.Id == Guid.Parse(request.ImageId));
                if (productImages != null)
                {
                    product.ProductImages.Remove(productImages);
                    await _productWriteRepository.SaveChangesAsync();
                    return new();
                }
                else
                {
                    return new();
                }

            }
            return new();
        }
    }
}
