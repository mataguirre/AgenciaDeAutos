using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaDeAutos.DTOs
{
    public class VehiculoDto
    {
        public string Patente { get; set; }
        public decimal Kilometros { get; set; }
        public int Anio { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Segmento { get; set; }
        public string Combustible { get; set; }
        public decimal PrecioVenta { get; set; }
        public string Observaciones { get; set; }
        public string Color { get; set; }
    }
}
