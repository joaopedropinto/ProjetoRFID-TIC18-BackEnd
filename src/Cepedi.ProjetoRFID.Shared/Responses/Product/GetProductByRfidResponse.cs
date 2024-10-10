namespace Cepedi.ProjetoRFID.Shared.Responses.Product;

public record GetProductByRfidResponse(Guid Id, Guid IdCategory, Guid IdSupplier, Guid IdPackaging, string Name, string RfidTag, string Description, decimal Weight,
    DateTime ManufacDate, DateTime DueDate, string UnitMeasurement, string BatchNumber, int Quantity,
    decimal Price, Guid IdReadout, decimal Height, decimal Width, decimal Length, decimal Volume, bool IsDeleted, string ImageObjectName);
