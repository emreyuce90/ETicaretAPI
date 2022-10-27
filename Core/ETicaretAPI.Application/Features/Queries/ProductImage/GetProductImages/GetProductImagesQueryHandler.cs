using ETicaretAPI.Application.Repositories.ProductRepo;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ETicaretAPI.Application.Features.Queries.ProductImage.GetProductImages
{
    public class GetProductImagesQueryHandler : IRequestHandler<GetProductImagesQueryRequest, List<GetProductImagesQueryResponse>>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IConfiguration _configuration;

        public GetProductImagesQueryHandler(IProductReadRepository productReadRepository, IConfiguration configuration)
        {
            _productReadRepository = productReadRepository;
            _configuration = configuration;
        }

        public async Task<List<GetProductImagesQueryResponse>> Handle(GetProductImagesQueryRequest request, CancellationToken cancellationToken)
        {
            //gelen id ye ait productların imagelerini de eager loading ile çek ve gelen id ye ait kaydı getir
            Domain.Entities.Product? p = await _productReadRepository.Table.Include(p => p.ProductImages).FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));
            if (p != null)
            {
               
               return p.ProductImages.Select(pi => new GetProductImagesQueryResponse
                {
                    FileName = pi.FileName,
                    Path = $"{_configuration["StorageDefaultPath"]}{pi.FilePath}",
                    Id = pi.Id.ToString()
                }).ToList();
                
            }
            return new();

        }

    }
}
