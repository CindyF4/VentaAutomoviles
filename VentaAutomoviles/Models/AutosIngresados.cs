using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VentaAutomoviles.Models
{
    public class AutosIngresados
    {
        public int Id { get; set; }
        public string? Marca { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Tipo { get; set; }
        public string? Placas { get; set; }
        public string? Color { get; set; }
        public string? Año { get; set; }
        public decimal Precio { get; set; }
    }
}
