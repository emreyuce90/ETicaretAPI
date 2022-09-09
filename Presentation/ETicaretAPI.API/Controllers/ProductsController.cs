using ETicaretAPI.Application.Repositories.ProductRepo;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers;



[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductReadRepository _productReadRepository;
    private readonly IProductWriteRepository _productWriteRepository;

    public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
    {
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
    }


    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        //await _productWriteRepository.AddAsync(new() { Name = "A",Price=81.18f,Stock=886 });
        //await _productWriteRepository.SaveChangesAsync();
        Product p = await _productReadRepository.GetByIdAsync("107A17AE-A37D-407C-5AA4-08DA92A1F223");
        p.Stock = 182;
        await _productWriteRepository.SaveChangesAsync();
        return Ok();
    }


}

