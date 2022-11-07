using ETicaretAPI.Application.Features.Commands.Product.AddProduct;
using ETicaretAPI.Application.Features.Commands.Product.RemoveProduct;
using ETicaretAPI.Application.Features.Commands.Product.UpdateProduct;
using ETicaretAPI.Application.Features.Commands.ProductImages.DeleteProductImage;
using ETicaretAPI.Application.Features.Commands.ProductImages.UploadProductImage;
using ETicaretAPI.Application.Features.Queries.Product.GetProductId;
using ETicaretAPI.Application.Features.Queries.Product.GetProductList;
using ETicaretAPI.Application.Features.Queries.ProductImage.GetProductImages;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers;


[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes ="Admin")]

public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery] GetProductListRequest getProductListRequest)
    {
        var response = await _mediator.Send(getProductListRequest);
        return Ok(response);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> Get([FromRoute]GetProductIdQueryRequest request)
    {
       var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody]AddProductRequest addProductRequest)
    {
        var response = await _mediator.Send(addProductRequest);
        if (response.IsSuccess)
            return Ok();
        return NotFound();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommandRequest updateProductCommandRequest)
    {
        var response= await _mediator.Send(updateProductCommandRequest);
        return Ok();
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteProduct([FromRoute]RemoveProductCommandRequest removeProductCommandRequest)
    {
        var response = await _mediator.Send(removeProductCommandRequest);
        if (response.IsSucess)
        {
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }
    
    
    [HttpPost("[action]")]
    public async Task<IActionResult> Upload([FromQuery]UploadPhotoImageCommandRequest request)
    {
        UploadPhotoImageCommandRequest req = new()
        {
            Files = Request.Form.Files,
            Id=request.Id,
        };
        await _mediator.Send(req);
        return Ok();
        
    }

    [HttpGet("[action]/{Id}")]
    public async Task<IActionResult> GetProductImages([FromRoute] GetProductImagesQueryRequest request)
    {
        var response =await _mediator.Send(request);
        return Ok(response);
    }

    [HttpDelete("[action]/{Id}")]
    public async Task<IActionResult> DeleteProductImage([FromRoute] string Id, [FromQuery] string ImageId)
    {
        DeleteProductImageCommandRequest request = new()
        {
            ImageId = ImageId,
            Id = Id
        };
        await _mediator.Send(request);
        return Ok();
    }


}

