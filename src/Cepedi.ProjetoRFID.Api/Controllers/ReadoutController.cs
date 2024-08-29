using Cepedi.ProjetoRFID.Shared.Exceptions;
using Cepedi.ProjetoRFID.Shared.Requests.Readout;
using Cepedi.ProjetoRFID.Shared.Responses.Readout;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.ProjetoRFID.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ReadoutController : BaseController
{
    private readonly ILogger<ReadoutController> _logger;
    private readonly IMediator _mediator;
    public ReadoutController(ILogger<ReadoutController> logger, IMediator mediator) : base(mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ReturnAllReadoutsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<ReturnAllReadoutsResponse>>> ReturnAllReadoutsAsync()
        => await SendCommand(new ReturnAllReadoutsRequest());

    [HttpPost]
    [ProducesResponseType(typeof(CreateReadoutResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreateReadoutResponse>> CreateReadoutAsync(
        [FromBody] CreateReadoutRequest request) => await SendCommand(request);


    [HttpGet("{Id}")]
    [ProducesResponseType(typeof(ReturnReadoutResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ReturnReadoutResponse>> ReturnReadoutAsync(
        [FromRoute] ReturnReadoutRequest request) => await SendCommand(request);
}