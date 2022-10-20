using MediatR;

namespace ETicaretAPI.Application.Features.Queries.Product.GetProductId
{
    public class GetProductIdQueryRequest:IRequest<GetProductIdQueryResponse>
    {
        public string Id { get; set; }
    }
}
