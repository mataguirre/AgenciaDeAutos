using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaDeAutos
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CUIT {  get; set; }
        public string Domicilio { get; set; }
        public int LocalidadId {  get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
}
