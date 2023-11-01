using System;

namespace AgenciaDeAutos.DTOs
{
    public class CreateUpdateVehiculoDto
    {
        public string Patente {  get; set; }
        public int Anio { get; set; }
        public Guid MarcadId { get; set; }
        public Guid CombustibleId { get; set; }
        public decimal Kilometros { get; set; }
        public Guid SegmentoId { get; set; }
        public decimal PrecioVenta { get; set; }
        public string Observaciones { get; set; }
        public string Modelo { get; set; }
        public string Color {  get; set; }
    }
}
