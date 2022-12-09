using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VentaAutomoviles.Models
{
    public class VentasPorAño
    {
        public int Id { get; set; }
        public string? Mes { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Año { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }
    }
}
