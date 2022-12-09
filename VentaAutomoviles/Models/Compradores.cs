using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VentaAutomoviles.Models
{
    public class Compradores
    {
        public int Id { get; set; }
        public string? Nombres { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Apellidos { get; set; }
        public string? DUI { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        
    }
}
