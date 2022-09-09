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
        //await _productWriteRepository.AddRangeAsync(new List<Product>()
        //{
        //    new(){ Id = Guid.NewGuid(),Stock =100,Name="Product 1"},
        //    new(){ Id = Guid.NewGuid(),Stock =200,Name="Product 2"},
        //    new(){ Id = Guid.NewGuid(),Stock =300,Name="Product 3"},
        //    new(){ Id = Guid.NewGuid(),Stock =400,Name="Product 4"},
        //});
        //await _productWriteRepository.SaveChangesAsync();
        //return Ok();
       var p = await _productReadRepository.GetByIdAsync("188f9fc1-adcd-4b8c-8f3d-03f31f98e34d",false);
        p.Name = "Yüce";
        await _productWriteRepository.SaveChangesAsync();
        return Ok();

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> FindById(string id)
    {
        Product p =await _productReadRepository.GetByIdAsync(id);
        return Ok(p);
    }
}

