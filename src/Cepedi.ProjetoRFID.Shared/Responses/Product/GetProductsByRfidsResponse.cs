public record class GetProductsByRfidsResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string RfidTag { get; init; }
    public string Description { get; init; }
    public decimal Weight { get; init; }
    public DateTime? ManufacDate { get; init; }
    public DateTime? DueDate { get; init; }
    public string UnitMeasurement { get; init; }
    public string BatchNumber { get; init; }
    public int Quantity { get; init; }
    public decimal Price { get; init; }
    public Guid IdReadout { get; init; }
    public Guid IdCategory { get; init; }
    public Guid IdSupplier { get; init; }
    public Guid IdPackaging { get; set; }
    public decimal Height { get; init; }
    public decimal Width { get; init; }
    public decimal Length { get; init; }
    public decimal Volume { get; init; }
    public string ImageObjectName { get; set; }
    public bool IsDeleted { get; set; } = false;

    public GetProductsByRfidsResponse(Guid id, string name, string rfidTag, string description, decimal weight, DateTime? manufacDate, DateTime? dueDate, string unitMeasurement, string batchNumber, int quantity, decimal price, Guid idReadout, Guid idCategory, Guid idSupplier, Guid idPackaging, decimal height, decimal width, decimal length, decimal volume, string imageObjectName, bool isDeleted)
    {
        Id = id;
        Name = name;
        RfidTag = rfidTag;
        Description = description;
        Weight = weight;
        ManufacDate = manufacDate;
        DueDate = dueDate;
        UnitMeasurement = unitMeasurement;
        BatchNumber = batchNumber;
        Quantity = quantity;
        Price = price;
        IdReadout = idReadout;
        IdCategory = idCategory;
        IdSupplier = idSupplier;
        IdPackaging = idPackaging;
        Height = height;
        Width = width;
        Length = length;
        Volume = volume;
        ImageObjectName = imageObjectName;
        IsDeleted = isDeleted;
    }
}
