using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaDeAutos
{
    public class Venta
    {
        public int ClienteId { get; set; }
        public int VehiculoId { get; set; }
        public DateTime FechaCompra {  get; set; }
        public DateTime FechaEntrega { get; set; }
        public decimal SubTotal {  get; set; }
        public decimal IVA { get; set; }
        public int Descuento { get; set; }
        public decimal Total { get; set; }
    }
}
