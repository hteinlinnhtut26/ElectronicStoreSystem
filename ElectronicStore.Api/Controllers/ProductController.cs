using ElectronicStore.Domain.Features.Product;
using ElectronicStore.Domain.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicStore.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductController()
    {
        _productService = new ProductService();
    }

    [HttpPost]
    public IActionResult CreateProduct(
        ProductCreateRequestModel request)
    {
        var response =
            _productService.CreateProduct(request);

        return Ok(response);
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        var request = new ProductListRequestModel();

        var response =
            _productService.GetProducts(request);

        return Ok(response);
    }

    [HttpGet("{productId}")]
    public IActionResult GetProductById(int productId)
    {
        var request = new ProductByIdRequestModel
        {
            ProductId = productId
        };

        var response =
            _productService.GetProductById(request);

        if (!response.IsSuccess)
        {
            return NotFound(response);
        }

        return Ok(response);
    }

    [HttpPut]
    public IActionResult UpdateProduct(
        ProductUpdateRequestModel request)
    {
        var response =
            _productService.UpdateProduct(request);

        return Ok(response);
    }

    [HttpDelete("{productId}")]
    public IActionResult DeleteProduct(int productId)
    {
        var request = new ProductDeleteRequestModel
        {
            ProductId = productId
        };

        var response =
            _productService.DeleteProduct(request);

        return Ok(response);
    }

    [HttpPost("Search")]
    public ProductSearchResponseModel SearchProducts(ProductSearchRequestModel model)
    {
        return _productService.SearchProducts(model);
    }

    [HttpPost("LowStock")]
    public ProductLowStockResponseModel GetLowStock(ProductLowStockRequestModel model)
    {
        return _productService.GetLowStockProducts(model);
    }

    [HttpPost("Restock")]
    public IActionResult Restock(ProductRestockRequestModel model)
    {
        var response = _productService.RestockProduct(model);
        return Ok(response);
    }
}