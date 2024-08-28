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
    public string PackingType { get; init; }
    public string BatchNumber { get; init; }
    public int Quantity { get; init; }
    public decimal Price { get; init; }
    public GetProductsByRfidsResponse(Guid id, string name, string rfidTag, string description, decimal weight, DateTime? manufacDate, DateTime? dueDate, string unitMeasurement, string packingType, string batchNumber, int quantity, decimal price)
    {
        Id = id;
        Name = name;
        RfidTag = rfidTag;
        Description = description;
        Weight = weight;
        ManufacDate = manufacDate;
        DueDate = dueDate;
        UnitMeasurement = unitMeasurement;
        PackingType = packingType;
        BatchNumber = batchNumber;
        Quantity = quantity;
        Price = price;
    }
}
