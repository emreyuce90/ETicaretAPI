﻿using ETicaretAPI.Application.Repositories.FileRepo;
using ETicaretAPI.Application.Repositories.InvoiceRepo;
using ETicaretAPI.Application.Repositories.ProductImageRepo;
using ETicaretAPI.Application.Repositories.ProductRepo;
using ETicaretAPI.Application.RequestParameters;
using ETicaretAPI.Application.Services;
using ETicaretAPI.Application.Services.Storages;
using ETicaretAPI.Application.ViewModels.ProductsVM;
using ETicaretAPI.Domain.Entities;
using File = ETicaretAPI.Domain.Entities.File;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.API.Controllers;



[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IProductReadRepository _productReadRepository;
    private readonly IProductWriteRepository _productWriteRepository;
    private readonly IFileReadReadRepository _fileReadRepository;
    private readonly IFileWriteRepository _fileWriteRepository;
    private readonly IProductImageWriteRepo _productImageWriteRepository;
    private readonly IProductImageReadRepository _productImageReadRepository;
    private readonly IInvoiceWriteRepository _invoiceWriteRepository;
    private readonly IInvoiceReadRepository _invoiceReadRepository;
    private readonly IStorageService _storageService;


    public ProductsController(
        IProductReadRepository productReadRepository,
        IProductWriteRepository productWriteRepository,
        IFileReadReadRepository fileReadRepository,
        IFileWriteRepository fileWriteRepository,
        IProductImageWriteRepo productImageWriteRepository,
        IProductImageReadRepository productImageReadRepository,
        IInvoiceWriteRepository invoiceWriteRepository,
        IInvoiceReadRepository invoiceReadRepository,
        IStorageService storageService,
        IConfiguration configuration)
    {
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
        _fileReadRepository = fileReadRepository;
        _fileWriteRepository = fileWriteRepository;
        _productImageWriteRepository = productImageWriteRepository;
        _productImageReadRepository = productImageReadRepository;
        _invoiceWriteRepository = invoiceWriteRepository;
        _invoiceReadRepository = invoiceReadRepository;
        _storageService = storageService;
        _configuration = configuration;
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
    public async Task<IActionResult> Upload([FromQuery] string id)
    {

        var datas = await _storageService.UploadAsync("product-images", Request.Form.Files);
        Product p = await _productReadRepository.GetByIdAsync(id);

        //dataları dön
        foreach (var r in datas)
        {
            //parametreden gelen product ile resimleri eşleştirebilmek için veritabanından ilgili product nesnesini çek
            p.ProductImages.Add(new ProductImages()
            {
                //123.png
                FileName = r.fileName,
                //product-images
                FilePath = r.path,
                //p
                Products = new List<Product>() { p },
                StorageName = _storageService.StorageName
            });
            //Bu nesneye filename,path i ver bu nesnenin product
        }
        //await _fileWriteRepository.AddRangeAsync(datas.Select(d=> new File() {FileName=d.fileName,FilePath = d.path,StorageName=_storageService.StorageName}).ToList());
        try
        {
            await _productWriteRepository.SaveChangesAsync();
        }
        catch (Exception ex)
        {

            throw ex;
        }

        return Ok();
    }

    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> GetProductImages([FromRoute] string id)
    {
        //gelen id ye ait productların imagelerini de eager loading ile çek ve gelen id ye ait kaydı getir
        Product? p = await _productReadRepository.Table.Include(p => p.ProductImages).FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));
        if (p != null)
            //Gelen productın productImageslerine select atarak istediğimiz değerleri anonim tür olarak clienta geri dönelim
            return Ok(p.ProductImages.Select(pi => new
            {
                pi.FileName,
                Path = $"{_configuration["StorageDefaultPath"]}{pi.FilePath}",
                pi.Id
            }));
        return NotFound();


    }

    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> DeleteProductImage([FromRoute]string id,[FromQuery]string ImageId)
    {
        //route tan gelen id ye ait product ı elde edelim
        Product? product = await _productReadRepository.Table.Include(p => p.ProductImages).FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));
        if (product != null)
        {
            ProductImages? productImages = product.ProductImages.FirstOrDefault(pi => pi.Id == Guid.Parse(ImageId));
            if (productImages != null)
            {
                product.ProductImages.Remove(productImages);
                await _productWriteRepository.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }
        return NotFound();
    }


}

