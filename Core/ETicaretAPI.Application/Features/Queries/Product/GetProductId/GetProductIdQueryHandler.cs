using ETicaretAPI.Application.Repositories.ProductRepo;
using MediatR;
using P = ETicaretAPI.Domain.Entities.Product;

namespace ETicaretAPI.Application.Features.Queries.Product.GetProductId
{
    public class GetProductIdQueryHandler : IRequestHandler<GetProductIdQueryRequest, GetProductIdQueryResponse>
    {
        private readonly IProductReadRepository _productReadRepository;

        public GetProductIdQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<GetProductIdQueryResponse> Handle(GetProductIdQueryRequest request, CancellationToken cancellationToken)
        {

            P p = await _productReadRepository.GetByIdAsync(request.Id, false);
            if (p != null)
                return new()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Stock = p.Stock
                };
            return new();
        }
    }
}
