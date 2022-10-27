using MediatR;
using Microsoft.AspNetCore.Http;

namespace ETicaretAPI.Application.Features.Commands.ProductImages.UploadProductImage
{
    public class UploadPhotoImageCommandRequest : IRequest<UploadPhotoImageCommandResponse>
    {
        public string Id { get; set; }
        public IFormFileCollection? Files { get; set; }
    }
}
