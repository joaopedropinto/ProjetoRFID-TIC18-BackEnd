using Cepedi.ProjetoRFID.Shared.Exceptions;
using Cepedi.ProjetoRFID.Shared.Requests.Packaging;
using Cepedi.ProjetoRFID.Shared.Responses.Packaging;
using Cepedi.ProjetoRFID.Shared.Responses.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.ProjetoRFID.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PackagingController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PackagingController> _logger;

        public PackagingController(IMediator mediator, ILogger<PackagingController> logger) : base(mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ReturnPackagingResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ReturnPackagingResponse>>> ReturnAllPackagingAsync()
            => await SendCommand(new ReturnAllPackagesRequest());

        [HttpGet("active")]
        [ProducesResponseType(typeof(List<ReturnPackagingResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ReturnPackagingResponse>>> ReturnAllActivePackagingAsync()
            => await SendCommand(new ReturnAllActivePackagesRequest());

        [HttpGet("{PackagingId}")]
        [ProducesResponseType(typeof(ReturnPackagingResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReturnPackagingResponse>> GetPackagingById(
            [FromRoute] ReturnPackagingByIdRequest request)
                => await SendCommand(request);

        [HttpPost]
        [ProducesResponseType(typeof(CreateProductResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreatePackagingResponse>> CreatePackagingAsync(
            [FromBody] CreatePackagingRequest request)
                => await SendCommand(request);

        [HttpPut]
        [ProducesResponseType(typeof(UpdatePackagingResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status204NoContent)]
        public async Task<ActionResult<UpdatePackagingResponse>> UpdatePackagingAsync(
            [FromBody] UpdatePackagingRequest request)
                => await SendCommand(request);

        [HttpDelete("{PackagingId}")]
        [ProducesResponseType(typeof(DeletePackagingResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status204NoContent)]
        public async Task<ActionResult<DeletePackagingResponse>> DeletePackagingAsync(
            [FromRoute] DeletePackagingRequest request)
                => await SendCommand(request);

    }
}
