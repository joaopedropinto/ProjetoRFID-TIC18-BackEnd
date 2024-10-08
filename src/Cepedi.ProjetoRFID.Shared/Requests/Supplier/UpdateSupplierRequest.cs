﻿using Cepedi.ProjetoRFID.Shared.Responses.Supplier;
using MediatR;
using OperationResult;

namespace Cepedi.ProjetoRFID.Shared.Requests.Supplier;


public class UpdateSupplierRequest : IRequest<Result<UpdateSupplierResponse>>, IValida
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? PhoneNumber { get; set; }
}
