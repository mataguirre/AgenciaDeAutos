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
            int opc;

            void Menu()
            {
                Console.Clear();
                Console.WriteLine("\tAgencia de Automóviles");
                Console.WriteLine("\n1) Listar automóviles");
                Console.WriteLine("2) Ingresar automóvil");
                Console.WriteLine("3) Remover automóvil");
                Console.WriteLine("4) Cerrar programa");
                Console.Write("\nIngrese una opción: ");
                if(!int.TryParse(Console.ReadLine(), out opc) || opc > 3 || opc < 1)
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese una opción válida");
                    Console.ReadKey();
                }
            }

            VehiculoService servicioVehiculos = new VehiculoService();

            Menu();

            while(opc != 4)
            {
                switch(opc)
                {
                    case 1:
                        servicioVehiculos.GetList();
                        break;
                    case 2:
                        servicioVehiculos.SetList();
                        break;
                    case 3:
                        servicioVehiculos.DeleteItem("ddo668");
                        break;
                }
                Menu();
            }

            Console.Clear();
            Console.WriteLine("\tAgencia de Automóviles");
            Console.Write("\nFinalizando programa...");
            Console.ReadKey();
        }
    }
}
