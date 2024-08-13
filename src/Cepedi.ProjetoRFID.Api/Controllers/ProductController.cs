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

    [HttpPost("get-products-by-rfids")]
    [ProducesResponseType(typeof(List<GetProductsByRfidsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<GetProductsByRfidsResponse>>> GetProductsByRfidsAsync([FromBody] GetProductsByRfidsRequest request)
    {
        return await SendCommand(request);
    }
}
