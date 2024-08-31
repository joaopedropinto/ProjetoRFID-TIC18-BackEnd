using System;
using Cepedi.ProjetoRFID.Shared.Responses.Product;
using MediatR;
using OperationResult;

namespace Cepedi.ProjetoRFID.Shared.Requests.Product;

public class GetProductByRfidRequest : IRequest<Result<GetProductByRfidResponse>>
{
    public string RfidTag { get; set; }
}
