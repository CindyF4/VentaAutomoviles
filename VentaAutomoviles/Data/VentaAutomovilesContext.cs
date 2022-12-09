using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentaAutomoviles.Models;

namespace VentaAutomoviles.Data
{
    public class VentaAutomovilesContext : DbContext
    {
        List<Autos> list;
        public VentaAutomovilesContext(DbContextOptions<VentaAutomovilesContext> options) : base(options)
        {

        }
        public DbSet<Autos> Autos { get; set; }
        public DbSet<Compradores> Compradores { get; set; }
        public DbSet<VentasPorMes> VentasPorMes { get; set; }
        public DbSet<VentasPorAño> VentasPorAño { get; set; }
        public DbSet<AutosIngresados> AutosIngresados { get; set; }

    }

    
   

}
