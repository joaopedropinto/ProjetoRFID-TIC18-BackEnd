namespace Cepedi.ProjetoRFID.Domain.Entities;

public class ProductEntity
{
    public Guid Id { get; set; }
    public Guid IdCategory { get; set; }
    public CategoryEntity? Category { get; set; }
    public Guid IdSupplier { get; set; }
    public SupplierEntity? Supplier { get; set; }
    public Guid IdReadout { get; set; }
    public string? Name { get; set; }
    public string? RfidTag { get; set; }
    // public RfidTagEntity? Tag { get; set; }
    public string? Description { get; set; }
    public decimal Weight { get; set; }
    public DateTime ManufacDate { get; set; }
    public DateTime DueDate { get; set; }
    public string? UnitMeasurement { get; set; }
    public string? PackingType { get; set; }
    public string? BatchNumber { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; } = 0;
    public decimal Height { get; set; } = 0;
    public decimal Width { get; set; } = 0;
    public decimal Length { get; set; } = 0;
    public decimal Volume { get; set; } = 0;

    public bool IsDeleted { get; set; } = false;

    internal void Update(Guid idCategory, Guid idSupplier, string name, string description, decimal weight, DateTime manufacDate, DateTime dueDate,
     string unitMeasurement, string packingType, string batchNumber, int quantity, decimal price, Guid idReadout, decimal height, decimal width, decimal length)
    {
        IdCategory = idCategory;
        IdSupplier = idSupplier;
        Name = name;
        Description = description;
        Weight = weight;
        ManufacDate = manufacDate;
        DueDate = dueDate;
        UnitMeasurement = unitMeasurement;
        PackingType = packingType;
        BatchNumber = batchNumber;
        Quantity = quantity;
        Price = price;
        IdReadout = idReadout;
        Height = height;
        Width = width;
        Length = length;
        Volume = height * width * length;
    }

    internal void Delete()
    {
        IsDeleted = true;
    }
}

