using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cepedi.ProjetoRFID.Domain.Entities;

public class SupplierEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? PhoneNumber { get; set; }

    internal void Update(string name, string description, string phoneNumber)
    {
        Name = name;
        Description = description;
        PhoneNumber = phoneNumber;
    }
}

