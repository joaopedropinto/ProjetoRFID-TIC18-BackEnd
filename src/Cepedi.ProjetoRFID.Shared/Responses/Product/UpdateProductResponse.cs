namespace Cepedi.ProjetoRFID.Shared.Responses.Product;

public record UpdateProductResponse(Guid Id, Guid IdCategory, Guid IdSupplier, Guid IdPackaging, string Name, string RfidTag, string Description, decimal Weight,
DateTime ManufacDate, DateTime DueDate, string UnitMeasurement, string BatchNumber, int Quantity,
decimal Price, Guid IdReadout, decimal Height, decimal Width, decimal Length, string ImageObjectname);

