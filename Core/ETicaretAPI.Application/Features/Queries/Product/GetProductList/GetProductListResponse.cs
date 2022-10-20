using ETicaretAPI.Application.ViewModels.ProductsVM;

namespace ETicaretAPI.Application.Features.Queries.Product.GetProductList
{
    public class GetProductListResponse
    {
        public object Products { get; set; }
        public int TotalCount { get; set; }
    }
}
    