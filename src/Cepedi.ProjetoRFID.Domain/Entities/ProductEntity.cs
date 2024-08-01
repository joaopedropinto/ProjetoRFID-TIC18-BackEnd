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
    public DateTime PurchaseDate { get; set; }
    public string? UnitMeasurement { get; set; }
    public string? PackingType { get; set; }
    public string? BatchNumber { get; set; }
    public int SugarLevel { get; set; }
    public string? Allergens { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; } = 0;

}

