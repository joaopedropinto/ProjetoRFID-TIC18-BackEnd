using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cepedi.ProjetoRFID.Domain.Entities;

public class CategoryEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Origin { get; set; }
    public string? Color { get; set; }

    internal void Update(string name, string origin, string color)
    {
        Name = name;
        Origin = origin;
        Color = color;
    }
}

