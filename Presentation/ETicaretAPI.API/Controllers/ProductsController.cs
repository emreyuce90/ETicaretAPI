using ETicaretAPI.Application.Repositories.ProductRepo;
using ETicaretAPI.Application.RequestParameters;
using ETicaretAPI.Application.Services;
using ETicaretAPI.Application.ViewModels.ProductsVM;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers;



[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IFileService _fileService;
    private readonly IProductReadRepository _productReadRepository;
    private readonly IProductWriteRepository _productWriteRepository;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IWebHostEnvironment webHostEnvironment, IFileService fileService)
    {
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
        _webHostEnvironment = webHostEnvironment;
        _fileService = fileService;
    }


    [HttpGet]
    public IActionResult GetProducts([FromQuery] Pagination pagination)
    {
        var products = _productReadRepository.GetAll(false).Skip(pagination.PageNumber * pagination.PageSize).Take(pagination.PageSize);
        var productsList = new ProductListWCount();
        List<ProductListViewModel> plvm = new List<ProductListViewModel>();
        foreach (var p in products)
        {
            //sana gelen productları gez her biri için bir nesne oluşturup bunu ProductListWCount a ekle
            ProductListViewModel m = new ProductListViewModel();

            m.CreatedDate = p.CreatedDate;
            m.Id = p.Id.ToString();
            m.ModifiedDate = p.ModifiedDate;
            m.Name = p.Name;
            m.Price = p.Price;
            m.Stock = p.Stock;
            plvm.Add(m);
        }
        productsList.ProductListViewModel = plvm;

        productsList.TotalCount = _productReadRepository.GetAll(false).Count();
        return Ok(productsList);
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
    [HttpPost("[action]")]
    public async Task<IActionResult> Upload()
    {
        await _fileService.UploadFileAsync("resources/productImages", Request.Form.Files);
        return Ok();
    }
}

