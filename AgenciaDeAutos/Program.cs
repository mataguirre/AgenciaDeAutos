using AgenciaDeAutos.DTOs;
using System;

namespace AgenciaDeAutos
{
    public class Program
    {
        static void Main(string[] args)
        {
            int opc;

            Vehiculo automovil = new Vehiculo()
            {
                Anio = 2005,
                Color = "Rojo",
                Kilometros = 150000,
                Modelo = "Astra",
                Observaciones = "Usado",
                PrecioVenta = 4500000,
                Patente = "DDO668".ToLower(),
                SegmentoId = Guid.Parse("922897ab-fe9d-439f-ab61-939a77811610"),
                MarcaId = Guid.Parse("322f7e5f-5e9a-4290-a7d3-a2556ce5460d"),
                CombustibleId = Guid.Parse("281c357b-f9c5-4449-9610-04a30557e455"),
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
                SegmentoId = Guid.Parse("0b225d69-d729-4659-a6c6-14e03be192fd"),
                MarcaId = Guid.Parse("f451a5a4-b036-487f-a10d-e87804d93c04"),
                CombustibleId = Guid.Parse("2fb22736-6ac4-4c5f-a846-ebb65eecccf1"),
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
                        Color = "Magenta",
                        Patente = automovil.Patente,
                    };
                    servicioVehiculos.UpdateVehicle(input);
                }
                Menu();
            }
        }
    }
}
