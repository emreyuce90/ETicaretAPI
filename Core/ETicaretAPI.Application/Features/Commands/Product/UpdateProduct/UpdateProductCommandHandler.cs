using ETicaretAPI.Application.Repositories.ProductRepo;
using MediatR;
using P = ETicaretAPI.Domain.Entities.Product;
namespace ETicaretAPI.Application.Features.Commands.Product.UpdateProduct
{
   
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public UpdateProductCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            P p = await _productReadRepository.GetByIdAsync(request.Id);
            if (p != null)
            {
                p.Price = request.Price;
                p.Stock = request.Stock;
                p.Name = request.Name;

                await _productWriteRepository.SaveChangesAsync();
                return new();
            }
            return new();
        }
    }
}
