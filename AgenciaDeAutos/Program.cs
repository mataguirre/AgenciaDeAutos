using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaDeAutos
{
    public class Program
    {
        static void Main(string[] args)
        {
            VehiculoService servicioVehiculos = new VehiculoService();
            servicioVehiculos.SetList();
        }
    }
}
