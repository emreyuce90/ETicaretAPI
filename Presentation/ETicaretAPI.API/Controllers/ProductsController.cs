using ETicaretAPI.Application.Repositories.ProductRepo;
using ETicaretAPI.Application.ViewModels.ProductsVM;
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

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        Product p = await _productReadRepository.GetByIdAsync(id, false);
        if (p != null)
        {
            return Ok(p);
        }
        return NotFound();

    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(ProductAddVM model)
    {
        if (ModelState.IsValid)
        {
            await _productWriteRepository.AddAsync(new Product() { Name = model.Name, Price = model.Price, Stock = model.Stock });
            await _productWriteRepository.SaveChangesAsync();
            return Created("", model);
        }
        return NotFound();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(ProductUpdateVM model)
    {
        Product p = await _productReadRepository.GetByIdAsync(model.Id);
        if (p != null)
        {
            p.Price = model.Price;
            p.Stock = model.Stock;
            p.Name = model.Name;

            await _productWriteRepository.SaveChangesAsync();
            return NoContent();
        }
        return NotFound();

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        if (id != null)
        {
            await _productWriteRepository.DeleteAsync(id);
            await _productWriteRepository.SaveChangesAsync();
            return NoContent();
        }
        return NotFound();

    }


}

