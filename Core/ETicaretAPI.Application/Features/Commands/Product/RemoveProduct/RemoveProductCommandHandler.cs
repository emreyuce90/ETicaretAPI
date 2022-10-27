using ETicaretAPI.Application.Repositories.ProductRepo;
using MediatR;

namespace ETicaretAPI.Application.Features.Commands.Product.RemoveProduct
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommandRequest, RemoveProductCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;

        public RemoveProductCommandHandler(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }

        public async Task<RemoveProductCommandResponse> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id != null)
            {
                await _productWriteRepository.DeleteAsync(request.Id);
                await _productWriteRepository.SaveChangesAsync();
                return new() { IsSucess = true };
            }
            return new() { IsSucess = false };

        }

    }
}

