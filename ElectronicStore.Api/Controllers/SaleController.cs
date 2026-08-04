using ElectronicStore.Domain.Features.Sale;
using ElectronicStore.Domain.Models.Sale;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicStore.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SaleController : ControllerBase
{
    private readonly SaleService _saleService;

    public SaleController()
    {
        _saleService = new SaleService();
    }

    [HttpPost]
    public IActionResult CreateSale(
    SaleCreateRequestModel request)
    {
        var response =
            _saleService.CreateSale(request);

        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpGet]
    public IActionResult GetSales()
    {
        var request = new SaleListRequestModel();

        var response =
            _saleService.GetSales(request);

        return Ok(response);
    }

    [HttpGet("{saleId}")]
    public IActionResult GetSaleById(int saleId)
    {
        var request = new SaleByIdRequestModel
        {
            SaleId = saleId
        };

        var response =
            _saleService.GetSaleById(request);

        if (!response.IsSuccess)
        {
            return NotFound(response);
        }

        return Ok(response);
    }

    [HttpPost("Search")]
    public IActionResult SearchSale(SaleSearchRequestModel model)
    {
        var response = _saleService.SearchSale(model);
        return Ok(response);
    }
}