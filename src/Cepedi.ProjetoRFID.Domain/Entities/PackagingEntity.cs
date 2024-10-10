using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cepedi.ProjetoRFID.Domain.Entities
{
    public class PackagingEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool IsDeleted { get; set; } = false;

        public void Update(string name)
        {
            Name = name;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
