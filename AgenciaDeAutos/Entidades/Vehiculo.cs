using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaDeAutos
{
    public class Vehiculo
    {
        public Guid Id { get; set; }
        public string Patente { get; set; }
        public decimal Kilometros {  get; set; }
        public int Anio {  get; set; }
        public Guid MarcaId { get; set; }
        public string Modelo { get; set; }
        public Guid SegmentoId { get; set; }
        public Guid CombustibleId { get; set; }
        public decimal PrecioVenta { get; set; }
        public string Observaciones { get; set; }
        public string Color { get; set; }
    }
}
