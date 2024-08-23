namespace Cepedi.ProjetoRFID.Shared.Responses.Product;

public record CreateProductResponse(Guid Id, int IdCategory, int IdSupplier, string Name, string RfidTag, string Description,
decimal Weight, DateTime ManufacDate, DateTime DueDate, string UnitMeasurement, string PackingType, string BatchNumber,
 int Quantity, decimal Price);
