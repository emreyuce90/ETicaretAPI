using MediatR;

namespace ETicaretAPI.Application.Features.Commands.Product.AddProduct
{
    public class AddProductRequest:IRequest<AddProductResponse>
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
    }
}
