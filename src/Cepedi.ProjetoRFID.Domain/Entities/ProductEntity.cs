using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cepedi.ProjetoRFID.Domain.Entities;

public class ProductEntity
{
    public int Id { get; set; }
    public int IdCategory { get; set; }
    public int IdSupplier { get; set; }
    public int IdTag { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Weight { get; set; }
    public DateTime ManufacDate { get; set; }
    public DateTime DueDate { get; set; }
    public string? UnitMeasurement { get; set; }
    public string? PackingType { get; set; }
    public string? BatchNumber { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; } = 0;

    internal void Update(string name, string description, decimal weight, DateTime manufacDate, DateTime dueDate,
     string unitMeasurement, string packingType, string batchNumber, int quantity, decimal price)
    {
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
    }
}

