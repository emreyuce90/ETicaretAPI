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
    public IActionResult GetProducts()
    {
        var products = _productReadRepository.GetAll(false);
        return Ok(products);
    }


}

