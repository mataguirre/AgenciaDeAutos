using AgenciaDeAutos.DTOs;
using AgenciaDeAutos.Servicios;
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

            Random random = new Random();

            Vehiculo automovil = new Vehiculo()
            {
                Anio = 2005,
                Color = "Rojo",
                Kilometros = 150000,
                Modelo = "Astra",
                Observaciones = "Usado",
                PrecioVenta = 4500000,
                Patente = "DDO668".ToLower(),
                SegmentoId = 2,
                MarcaId = 1,
                CombustibleId = 4,
            };

            Vehiculo automovil1 = new Vehiculo()
            {
                Anio = 2016,
                Color = "Blanco",
                Kilometros = 100000,
                Modelo = "408",
                Observaciones = "Usado",
                PrecioVenta = 15000000,
                Patente = "AA647YC".ToLower(),
                SegmentoId = 1,
                MarcaId = 2,
                CombustibleId = 3,
            };

            void Menu()
            {
                Console.Clear();
                Console.WriteLine("\tAgencia de Automóviles");
                Console.WriteLine("\n1) Listar automóviles");
                Console.WriteLine("2) Ingresar automóvil");
                Console.WriteLine("3) Remover automóvil");
                Console.WriteLine("4) Actualizar automóvil");
                Console.WriteLine("5) Cerrar programa");
                Console.Write("\nIngrese una opción: ");
                if (!int.TryParse(Console.ReadLine(), out opc) || opc > 5 || opc < 1)
                {
                    Console.Clear();
                    Console.WriteLine("\tAgencia de Automóviles");
                    Console.WriteLine("\n1) Listar automóviles");
                    Console.WriteLine("2) Ingresar automóvil");
                    Console.WriteLine("3) Remover automóvil");
                    Console.WriteLine("4) Actualizar automóvil");
                    Console.WriteLine("5) Cerrar programa");
                    Console.Write("\nIngrese una opción válida");
                    Console.ReadKey();
                }
            }
            VehiculoService servicioVehiculos = new VehiculoService();

            Menu();
            while (opc != 5)
            {
                if(opc == 1)
                {
                    var vehiculos = servicioVehiculos.GetVehicles();
                    Console.Clear();
                    Console.WriteLine("\tAgencia de Automóviles");
                    foreach (var vehiculo in vehiculos)
                    {
                        Console.WriteLine("\nPatente: {0}", vehiculo.Patente);
                        Console.WriteLine("Marca: {0}", vehiculo.Marca);
                        Console.WriteLine("Modelo: {0}", vehiculo.Modelo);
                        Console.WriteLine("Combustible: {0}", vehiculo.Combustible);
                        Console.WriteLine("Segmento: {0}", vehiculo.Segmento);
                        Console.WriteLine("Año: {0}", vehiculo.Anio);
                        Console.WriteLine("Kilometros: {0}", vehiculo.Kilometros);
                        Console.WriteLine("Modelo: {0}", vehiculo.Modelo);
                        Console.WriteLine("Color: {0}", vehiculo.Color);
                        Console.WriteLine("Observaciones: {0}", vehiculo.Observaciones);
                        Console.WriteLine("Precio Venta: ${0}", vehiculo.PrecioVenta);
                    }
                    Console.ReadKey();
                } else if(opc == 2)
                {
                    CreateUpdateVehiculoDto input = new CreateUpdateVehiculoDto()
                    {
                        Anio = automovil.Anio,
                        Color = automovil.Color,
                        Kilometros = automovil.Kilometros,
                        Modelo = automovil.Modelo,
                        PrecioVenta = automovil.PrecioVenta,
                        Patente = automovil.Patente,
                        SegmentoId = automovil.SegmentoId,
                        MarcadId = automovil.MarcaId,
                        CombustibleId = automovil.CombustibleId,
                        Observaciones = automovil.Observaciones
                    };

                    servicioVehiculos.CreateVehicle(input);

                    CreateUpdateVehiculoDto input1 = new CreateUpdateVehiculoDto()
                    {
                        Anio = automovil1.Anio,
                        Color = automovil1.Color,
                        Kilometros = automovil1.Kilometros,
                        Modelo = automovil1.Modelo,
                        PrecioVenta = automovil1.PrecioVenta,
                        Patente = automovil1.Patente,
                        SegmentoId = automovil1.SegmentoId,
                        MarcadId = automovil1.MarcaId,
                        CombustibleId = automovil1.CombustibleId,
                        Observaciones = automovil1.Observaciones
                    };

                    servicioVehiculos.CreateVehicle(input1);
                } else if(opc == 3)
                {
                    servicioVehiculos.DeleteVehicle(automovil.Patente);
                } else if(opc == 4)
                {
                    CreateUpdateVehiculoDto input = new CreateUpdateVehiculoDto()
                    {
                        PrecioVenta = 15600000,
                        Patente = automovil.Patente,
                    };
                    servicioVehiculos.UpdateVehicle(input);
                }
                Menu();
            }
        }
    }
}
