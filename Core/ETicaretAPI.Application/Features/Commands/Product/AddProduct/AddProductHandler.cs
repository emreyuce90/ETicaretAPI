using ETicaretAPI.Application.Repositories.ProductRepo;
using MediatR;
using P =  ETicaretAPI.Domain.Entities;
namespace ETicaretAPI.Application.Features.Commands.Product.AddProduct
{
    public class AddProductHandler : IRequestHandler<AddProductRequest, AddProductResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;

        public AddProductHandler(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }

        public async Task<AddProductResponse> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {

            await _productWriteRepository.AddAsync(new P.Product() { Name = request.Name, Price = request.Price, Stock = request.Stock });
            await _productWriteRepository.SaveChangesAsync();
            return new()
            {
                IsSuccess = true
            };
        }
    }
}
