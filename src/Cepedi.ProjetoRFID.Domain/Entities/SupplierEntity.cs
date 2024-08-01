﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cepedi.ProjetoRFID.Domain.Entities;

public class SupplierEntity
{
    public int Id { get; set; }
    public int IdProduct { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? PhoneNumber { get; set; }

}
