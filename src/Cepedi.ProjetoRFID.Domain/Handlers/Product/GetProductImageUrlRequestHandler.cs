using Cepedi.ProjetoRFID.Domain.Services;
using Cepedi.ProjetoRFID.Shared.Requests.Product;
using Cepedi.ProjetoRFID.Shared.Responses.Product;
using MediatR;
using OperationResult;

namespace Cepedi.ProjetoRFID.Domain.Handlers.Product
{
	public class GetProductImageUrlRequestHandler
		: IRequestHandler<GetProductImageUrlRequest, Result<GetProductImageUrlResponse>>
	{
		private readonly IMinioService _minioService;

		public GetProductImageUrlRequestHandler(IMinioService minioService) 
			=> _minioService = minioService;

		public async Task<Result<GetProductImageUrlResponse>> Handle(GetProductImageUrlRequest request, CancellationToken cancellationToken)
		{
			var url = await _minioService.GetObjectUrlAsync("rfid-product-images", request.ObjectName);

			var response = new GetProductImageUrlResponse(url);

			return Result.Success(response);
		}
	}
}
