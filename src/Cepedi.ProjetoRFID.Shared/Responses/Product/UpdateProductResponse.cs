namespace Cepedi.ProjetoRFID.Shared.Responses.Product;

public record UpdateProductResponse(Guid Id, Guid IdCategory, Guid IdSupplier, string Name, string RfidTag, string Description, decimal Weight,
DateTime ManufacDate, DateTime DueDate, string UnitMeasurement, string PackingType, string BatchNumber, int Quantity,
decimal Price, Guid IdReadout);
