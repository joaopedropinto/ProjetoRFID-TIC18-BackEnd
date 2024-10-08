using Cepedi.ProjetoRFID.Shared.Exceptions;
using Cepedi.ProjetoRFID.Shared.Requests.Product;
using Cepedi.ProjetoRFID.Shared.Responses.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.ProjetoRFID.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : BaseController
{
    private readonly ILogger<ProductController> _logger;
    private readonly IMediator _mediator;
    public ProductController(ILogger<ProductController> logger, IMediator mediator) : base(mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ReturnAllProductsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<ReturnAllProductsResponse>>> ReturnAllProductsAsync()
        => await SendCommand(new ReturnAllProductsRequest());

    [HttpGet("active")]
    [ProducesResponseType(typeof(List<ReturnAllActiveProductsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<ReturnAllActiveProductsResponse>>>
        ReturnAllActiveProductsAsync() => await SendCommand(new ReturnAllActiveProductsRequest());

    [HttpPost]
    [ProducesResponseType(typeof(CreateProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreateProductResponse>> CreateProductAsync(
        [FromBody] CreateProductRequest request) => await SendCommand(request);

    [HttpPut]
    [ProducesResponseType(typeof(UpdateProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<UpdateProductResponse>> UpdateProductAsync(
        [FromBody] UpdateProductRequest request) => await SendCommand(request);

    [HttpGet("{Id}")]
    [ProducesResponseType(typeof(ReturnProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ReturnProductResponse>> ReturnProductAsync(
        [FromRoute] ReturnProductRequest request) => await SendCommand(request);

    [HttpDelete("{Id}")]
    [ProducesResponseType(typeof(DeleteProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<DeleteProductResponse>> DeleteProductAsync(
        [FromRoute] DeleteProductRequest request) => await SendCommand(request);

    [HttpGet("get-products-by-rfids")]
    [ProducesResponseType(typeof(CombinedProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CombinedProductResponse>> GetProductsByRfidsAsync()
    {
        var request = new GetProductsByRfidsRequest(new List<string>());
        var result = await _mediator.Send(request);

        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        else
        {
            return Ok(result.Value);
        }
    }

    [HttpGet("get-product-by-rfid")]
    [ProducesResponseType(typeof(GetProductByRfidResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetProductByRfidResponse>> GetProductByRfidAsync(
        [FromQuery] GetProductByRfidRequest request)
    {
        var result = await _mediator.Send(request);

        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        else
        {
            return Ok(result.Value);
        }
    }
}
