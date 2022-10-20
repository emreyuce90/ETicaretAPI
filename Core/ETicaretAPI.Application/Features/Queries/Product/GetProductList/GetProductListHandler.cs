using ETicaretAPI.Application.Repositories.ProductRepo;
using ETicaretAPI.Application.RequestParameters;
using ETicaretAPI.Application.ViewModels.ProductsVM;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.Application.Features.Queries.Product.GetProductList
{
    public class GetProductListHandler : IRequestHandler<GetProductListRequest, GetProductListResponse>
    {
        private readonly IProductReadRepository _productReadRepository;
        public GetProductListHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }
        public async Task<GetProductListResponse> Handle(GetProductListRequest request, CancellationToken cancellationToken)
        {
            var products = await _productReadRepository.GetAll(false).Skip(request.PageNumber * request.PageSize).Take(request.PageSize).Select(p => new
            {
                p.Price,
                p.Id,
                p.Stock,
                p.CreatedDate,
                p.ModifiedDate,
                p.Name
            }).ToListAsync();

            int totalCount = await _productReadRepository.GetAll(false).CountAsync();

            return new GetProductListResponse()
            {
                Products = products,
                TotalCount = totalCount
            };
        }
    }
}
