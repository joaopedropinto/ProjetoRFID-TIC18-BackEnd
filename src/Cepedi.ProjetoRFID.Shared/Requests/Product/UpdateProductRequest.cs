using Cepedi.ProjetoRFID.Shared.Responses.Product;
using MediatR;
using OperationResult;

namespace Cepedi.ProjetoRFID.Shared.Requests.Product;

public class UpdateProductRequest : IRequest<Result<UpdateProductResponse>>, IValida
{
    public Guid Id { get; set; }
    public Guid IdCategory { get; set; }
    public Guid IdSupplier { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Weight { get; set; }
    public DateTime ManufacDate { get; set; }
    public DateTime DueDate { get; set; }
    public string? UnitMeasurement { get; set; }
    public string? PackingType { get; set; }
    public string? BatchNumber { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; } = 0;
    public Guid IdReadout { get; set; }

    public decimal Heigth { get; set; } = 0;
    public decimal Width { get; set; } = 0;
    public decimal Length { get; set; } = 0;

}
