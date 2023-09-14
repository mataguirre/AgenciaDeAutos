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
        public int MarcaId { get; set; }
        public string Modelo { get; set; }
        public int SegmentoId { get; set; }
        public int CombustibleId { get; set; }
        public decimal PrecioVenta { get; set; }
        public string Observaciones { get; set; }
    }
}
