using MediatR;

namespace ETicaretAPI.Application.Features.Commands.ProductImages.DeleteProductImage
{
    public class DeleteProductImageCommandRequest:IRequest<DeleteProductImageCommandResponse>
    {
        public string Id { get; set; }
        public string ImageId { get; set; }
    }
}
