﻿namespace Cepedi.ProjetoRFID.Shared.Responses.Product;

public record DeleteProductResponse(Guid Id, Guid IdCategory, Guid IdSupplier, string Name, string RfidTag, string Description, decimal Weight,
DateTime ManufacDate, DateTime DueDate, string UnitMeasurement, string PackingType, string BatchNumber, int Quantity,
decimal Price, decimal Height, decimal Width, decimal Length, decimal Volume);
