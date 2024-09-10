using Cepedi.ProjetoRFID.Shared.Responses.Readout;
using MediatR;
using OperationResult;
using System.Collections.Generic;


namespace Cepedi.ProjetoRFID.Shared.Requests.Readout;

public class ReturnAllReadoutsRequest : IRequest<Result<List<ReturnAllReadoutsResponse>>>
{

}
