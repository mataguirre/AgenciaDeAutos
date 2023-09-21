﻿using AgenciaDeAutos.Entidades;
using AgenciaDeAutos.Servicios;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaDeAutos
{
    public class VehiculoService
    {
        private PatenteService _patenteService = new PatenteService();
        private List<Patente> _patentesRepository = new List<Patente>();
        private StreamReader _sr;
        private StreamWriter _sw;
        private FileStream _file;
        private Guid _id;
        private string _patente;
        private decimal _kilometros;
        private int _anio;
        private int _marcaId;
        private string _modelo;
        private int _segmentoId;
        private int _combustibleId;
        private decimal _precioVenta;
        private string _observaciones;
        private List<Vehiculo> _vehiculosRepository = new List<Vehiculo>();
        private readonly string _vehiculosFilePath = "Vehiculos.txt";
        private readonly string _patentesFilePath = "Patentes.txt";
        private readonly string _marcasFilePath = "Marcas.txt";
        private readonly string _combustiblesFilePath = "Combustibles.txt";
        private readonly string _segmentosFilePath = "Segmentos.txt";
        private bool onInit = true;
        private int _vehiculosCount;
        int anchoTotal = 105;

        public VehiculoService()
        {
            _vehiculosRepository = GetList(false);
            _patentesRepository = _patenteService.GetList(false);
        }
        public List<Vehiculo> GetList(bool info = true)
        {
            if (File.Exists(_vehiculosFilePath))
            {
                if (info)
                {
                    Console.Clear();
                    // Imprimir la parte superior de la tabla
                    Console.WriteLine("\tListado de Herramientas\n");
                    Console.WriteLine(new string('-', anchoTotal));
                    Console.WriteLine($"| {"Patente", -7} | {"Año",-5} | {"Combustible",-4} | {"Kilometros", -10} | {"Segmento",-4} | {"Precio", -5} | {"Observaciones",-10} | {"Modelo", -5} | {"Marca",-5} |");
                    Console.WriteLine(new string('-', anchoTotal));
                }
                _file = new FileStream(_vehiculosFilePath, FileMode.Open);
                _sr = new StreamReader(_file);

                if (_vehiculosRepository.Count() == 0 && onInit)
                {
                    if (!_sr.EndOfStream)
                    {
                        _vehiculosCount = 0;
                        while (!_sr.EndOfStream)
                        {
                            string[] fields = _sr.ReadLine().Split(';');

                            if (info)
                            {
                                Console.WriteLine(
                                    $"| {fields[1], -7} | {fields[2], -5} | {fields[3], -4} | {fields[4], -4} | {fields[5], -10} | ${fields[6], -4} | {fields[7], -5} | {fields[8], -10} | {fields[9], -5} |"
                                );
                                Console.WriteLine(new string('-', anchoTotal));
                            }

                            Vehiculo _vehiculo = new Vehiculo();
                            _vehiculo.Id = Guid.Parse(fields[0]);
                            _vehiculo.Patente = fields[1];
                            _vehiculo.Anio = int.Parse(fields[2]);
                            _vehiculo.CombustibleId = int.Parse(fields[3]);
                            _vehiculo.Kilometros = decimal.Parse(fields[4]);
                            _vehiculo.SegmentoId = int.Parse(fields[5]);
                            _vehiculo.PrecioVenta = decimal.Parse(fields[6]);
                            _vehiculo.Observaciones = fields[7];
                            _vehiculo.Modelo = fields[8];
                            _vehiculo.MarcaId = int.Parse(fields[9]);

                            _vehiculosRepository.Add(_vehiculo);
                            _vehiculosCount++;
                        }
                        if (info)
                        {
                            Console.Write($"\nCantidad de automóviles: {_vehiculosCount}");
                            Console.ReadKey();
                        }
                        onInit = false;
                    }
                    else
                    {
                        if (info)
                        {
                            Console.Clear();
                            Console.WriteLine("\tAgencia de Automóviles");
                            Console.Write("\nAún no se ingresaron automóviles");
                            Console.ReadKey();
                        }
                    }
                }
                else
                {
                    _vehiculosCount = 0;
                    while (!_sr.EndOfStream)
                    {
                        string[] fields = _sr.ReadLine().Split(';');

                        if (info)
                        {
                            Console.WriteLine(
                                $"| {fields[1], -7} | {fields[2], -5} | {fields[3], -4} | {fields[4], -4} | {fields[5], -10} | ${fields[6], -4} | {fields[7], -5} | {fields[8], -10} | {fields[9], -5} |"
                            );
                            Console.WriteLine(new string('-', anchoTotal));
                        }
                        _vehiculosCount++;
                    }
                    if (info)
                    {
                        Console.Write($"\nCantidad de automóviles: {_vehiculosCount}");
                        Console.ReadKey();
                    }
                }
                _sr.Close();
                _file.Close();
            }
            else
            {
                if (info)
                {
                    Console.Clear();
                    Console.WriteLine("\tAgencia de Automóviles");
                    Console.Write("\nConcesionaria inhabilitada por el momento");
                    Console.ReadKey();
                }
            }
            return _vehiculosRepository;
        }

        public void SetList()
        {
            Console.Clear();
            if (!File.Exists(_vehiculosFilePath))
            {
                Console.WriteLine("\tAgencia de Automóviles");
                /* Instancio la clase FileStream */
                _file = new FileStream(_vehiculosFilePath, FileMode.Create);
                /* Instancio la clase StreamReader */
                _sw = new StreamWriter(_file);
                /* Asigno el ID */
                _id = Guid.NewGuid();
                /* Ingreso la patente */
                Console.Write("\nIngrese patente: ");
                _patente = Console.ReadLine().ToLower();
                /* Ingreso kilometros */
                Console.Write("Ingrese kilometros: ");
                _kilometros = decimal.Parse(Console.ReadLine());
                /* Ingreso año */
                Console.Write("Ingrese año: ");
                _anio = int.Parse(Console.ReadLine());
                /* Ingrese ID de marca */
                Console.Write("Ingrese ID de marca: ");
                _marcaId = int.Parse(Console.ReadLine());
                /* Ingreso modelo */
                Console.Write("Ingrese modelo: ");
                _modelo = Console.ReadLine();
                /* Ingreso ID de segmento */
                Console.Write("Ingrese ID de segmento: ");
                _segmentoId = int.Parse(Console.ReadLine());
                /* Ingreso ID de combustible */
                Console.Write("Ingrese ID de combustible: ");
                _combustibleId = int.Parse(Console.ReadLine());
                /* Ingreso precio de venta */
                Console.Write("Ingrese precio de venta: $");
                _precioVenta = decimal.Parse(Console.ReadLine());
                /* Ingreso observaciones */
                Console.Write("Ingrese observaciones: ");
                _observaciones = Console.ReadLine();

                Vehiculo _vehiculo = new Vehiculo();
                _vehiculo.Id = _id;
                _vehiculo.Patente = _patente;
                _vehiculo.Anio = _anio;
                _vehiculo.MarcaId = _marcaId;
                _vehiculo.CombustibleId = _combustibleId;
                _vehiculo.Kilometros = _kilometros;
                _vehiculo.SegmentoId = _segmentoId;
                _vehiculo.PrecioVenta = _precioVenta;
                _vehiculo.Observaciones = _observaciones;
                _vehiculo.Modelo = _modelo;

                _vehiculosRepository.Add(_vehiculo);

                _sw.WriteLine(
                    $"{_id};{_patente};{_anio};{_combustibleId};{_kilometros};{_segmentoId};{_precioVenta};{_observaciones};{_modelo};{_marcaId}"
                );

                _sw.Close();
                _file.Close();

                _patenteService.SetList(_vehiculo.Patente);
                Console.Write("\nAutomóvil ingresado correctamente");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\tAgencia de Automóviles");
                /* Instancio la clase FileStream */
                _file = new FileStream(_vehiculosFilePath, FileMode.Append);
                /* Instancio la clase StreamReader */
                _sw = new StreamWriter(_file);
                /* Asigno el ID */
                _id = Guid.NewGuid();
                /* Ingreso la patente */
                Console.Write("\nIngrese patente: ");
                _patente = Console.ReadLine().ToLower();
                /* Verifico que la patente no exista */
                if (!_patentesRepository.Any(x => x.Nombre == _patente))
                {
                    /* Ingreso kilometros */
                    Console.Write("Ingrese kilometros: ");
                    _kilometros = decimal.Parse(Console.ReadLine());
                    /* Ingreso año */
                    Console.Write("Ingrese año: ");
                    _anio = int.Parse(Console.ReadLine());
                    /* Ingrese ID de marca */
                    Console.Write("Ingrese ID de marca: ");
                    _marcaId = int.Parse(Console.ReadLine());
                    /* Ingreso modelo */
                    Console.Write("Ingrese modelo: ");
                    _modelo = Console.ReadLine();
                    /* Ingreso ID de segmento */
                    Console.Write("Ingrese ID de segmento: ");
                    _segmentoId = int.Parse(Console.ReadLine());
                    /* Ingreso ID de combustible */
                    Console.Write("Ingrese ID de combustible: ");
                    _combustibleId = int.Parse(Console.ReadLine());
                    /* Ingreso precio de venta */
                    Console.Write("Ingrese precio de venta: $");
                    _precioVenta = decimal.Parse(Console.ReadLine());
                    /* Ingreso observaciones */
                    Console.Write("Ingrese observaciones: ");
                    _observaciones = Console.ReadLine();

                    Vehiculo _vehiculo = new Vehiculo();
                    _vehiculo.Id = _id;
                    _vehiculo.Patente = _patente;
                    _vehiculo.Anio = _anio;
                    _vehiculo.CombustibleId = _combustibleId;
                    _vehiculo.Kilometros = _kilometros;
                    _vehiculo.SegmentoId = _segmentoId;
                    _vehiculo.PrecioVenta = _precioVenta;
                    _vehiculo.Observaciones = _observaciones;
                    _vehiculo.Modelo = _modelo;
                    _vehiculo.MarcaId = _marcaId;

                    _vehiculosRepository.Add(_vehiculo);

                    _sw.WriteLine(
                        $"{_id};{_patente};{_anio};{_combustibleId};{_kilometros};{_segmentoId};{_precioVenta};{_observaciones};{_modelo};{_marcaId}"
                    );

                    _sw.Close();
                    _file.Close();

                    _patenteService.SetList(_patente);
                    Console.Write("\nAutomóvil ingresado correctamente");
                    Console.ReadKey();

                    return;
                }
                Console.Clear();
                Console.WriteLine("\tAgencia de Automóviles");
                Console.Write("\nEste automóvil ya fue previamente ingresado");
                _sw.Close();
                _file.Close();
                Console.ReadKey();
            }
        }

        public void DeleteItem()
        {
            if (File.Exists(_vehiculosFilePath))
            {
                Console.Clear();
                Console.WriteLine("\tAgencia de Automóviles");
                Console.Write("\nIngrese la patente del automóvil a retirar: ");
                string patente = Console.ReadLine();
                Vehiculo _vehiculoARemover = new Vehiculo();
                /* Verifico si existe el automóvil en el repositorio */
                bool vehiculoEncontrado = false;
                int indexToRemove = -1;

                for (int i = 0; i < _vehiculosRepository.Count; i++)
                {
                    if (_vehiculosRepository[i].Patente == patente)
                    {
                        _vehiculoARemover = _vehiculosRepository[i];
                        vehiculoEncontrado = true;
                        indexToRemove = i;
                        break;
                    }
                }

                if (vehiculoEncontrado)
                {
                    /* Leer todas las líneas del archivo excepto la que se va a eliminar */
                    List<string> vehiculos = File.ReadAllLines(_vehiculosFilePath).ToList();
                    vehiculos.RemoveAt(indexToRemove); // Eliminar la línea correspondiente al vehículo
                    /* Escribir las líneas actualizadas en el archivo */
                    File.WriteAllLines(_vehiculosFilePath, vehiculos);

                    _patenteService.DeleteItem(patente);

                    _vehiculosRepository.Remove(_vehiculoARemover);

                    Console.Clear();
                    Console.WriteLine("\tAgencia de Automóviles");
                    Console.Write("\nAutomóvil retirado correctamente");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\tAgencia de Automóviles");
                    Console.Write(
                        "\nEl autómovil que desea remover no se encuentra en la concesionaria"
                    );
                    Console.ReadKey();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\tAgencia de Automóviles");
                Console.Write("\nConcesionaria inhabilitada por el momento");
                Console.ReadKey();
            }
        }
    }
}
