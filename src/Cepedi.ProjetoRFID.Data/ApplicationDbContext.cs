using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cepedi.ProjetoRFID.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.ProjetoRFID.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<RfidTagEntity> RfidTag { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=localhost;Database=ProjetoRFID;Trusted_Connection=True;");
        }
    }


}
