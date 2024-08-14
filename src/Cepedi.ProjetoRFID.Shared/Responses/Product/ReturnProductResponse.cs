namespace Cepedi.ProjetoRFID.Shared.Responses.Product;

public record ReturnProductResponse(int Id, int IdCategory, int IdSupplier, string Name, string RifdTag, string Description, decimal Weight,
DateTime ManufacDate, DateTime DueDate, string UnitMeasurement, string PackingType, string BatchNumber, int Quantity,
decimal Price);
