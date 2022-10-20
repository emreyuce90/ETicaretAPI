using MediatR;

namespace ETicaretAPI.Application.Features.Queries.Product.GetProductList
{
    public class GetProductListRequest:IRequest<GetProductListResponse>
    {
        public int PageSize { get; set; } = 5;
        public int PageNumber { get; set; } = 0;
        public int TotalDataCount { get; set; }
    }
}
