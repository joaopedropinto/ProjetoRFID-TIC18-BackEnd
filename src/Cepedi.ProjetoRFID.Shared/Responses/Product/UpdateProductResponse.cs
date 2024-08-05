namespace Cepedi.ProjetoRFID.Shared.Responses.Product;

public record UpdateProductResponse(int Id, int IdCategory, int IdSupplier, int IdTag, string Name, string Description, decimal Weight, 
DateTime ManufacDate, DateTime DueDate, string UnitMeasurement, string PackingType, string BatchNumber, int Quantity, 
decimal Price);
