using AgenciaDeAutos.Entidades;
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

        public VehiculoService() { }

        public VehiculoService(
            string patente,
            decimal kilometros,
            int anio,
            int marcaId,
            string modelo,
            int segmentoId,
            int combustibleId,
            decimal precioVenta,
            string observaciones
        )
        {
            _patente = patente;
            _kilometros = kilometros;
            _anio = anio;
            _marcaId = marcaId;
            _modelo = modelo;
            _segmentoId = segmentoId;
            _combustibleId = combustibleId;
            _precioVenta = precioVenta;
            _observaciones = observaciones;
        }

        public List<Vehiculo> GetList(bool info = true)
        {
            if (File.Exists(_vehiculosFilePath))
            {
                Console.Clear();
                Console.WriteLine("\tListado de Automóviles");

                _file = new FileStream(_vehiculosFilePath, FileMode.Open);
                _sr = new StreamReader(_file);

                if (_vehiculosRepository.Count() == 0 || onInit)
                {
                    if (!_sr.EndOfStream)
                    {
                        _vehiculosCount = 0;
                        while (!_sr.EndOfStream)
                        {
                            string[] fields = _sr.ReadLine().Split(';');

                            if (info)
                            {
                                Console.WriteLine($"\nPatente: {fields[1]}");
                                Console.WriteLine($"Modelo: {fields[8]}");
                                Console.WriteLine($"Año: {fields[2]}");
                                Console.WriteLine($"Combustible: {fields[3]}");
                                Console.WriteLine($"Kilometros: {fields[4]} km");
                                Console.WriteLine($"Segmento: {fields[5]}");
                                Console.WriteLine($"Precio de Venta: ${fields[6]}");
                                Console.WriteLine($"Observaciones: {fields[7]}");
                                Console.WriteLine($"Marca: {fields[9]}");
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
                    if (info)
                    {
                        _vehiculosCount = 0;
                        while (!_sr.EndOfStream)
                        {
                            string[] fields = _sr.ReadLine().Split(';');

                            if (info)
                            {
                                Console.WriteLine($"\nPatente: {fields[1]}");
                                Console.WriteLine($"Modelo: {fields[8]}");
                                Console.WriteLine($"Año: {fields[2]}");
                                Console.WriteLine($"Combustible: {fields[3]}");
                                Console.WriteLine($"Kilometros: {fields[4]} km");
                                Console.WriteLine($"Segmento: {fields[5]}");
                                Console.WriteLine($"Precio de Venta: ${fields[6]}");
                                Console.WriteLine($"Observaciones: {fields[7]}");
                                Console.WriteLine($"Marca: {fields[9]}");
                            }
                            _vehiculosCount++;
                        }
                        if (info)
                        {
                            Console.Write($"\nCantidad de automóviles: {_vehiculosCount}");
                            Console.ReadKey();
                        }
                    }
                }
                _sr.Close();
                _file.Close();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\tAgencia de Automóviles");
                Console.Write("\nConcesionaria inhabilitada por el momento");
                Console.ReadKey();
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
                _patentesRepository = _patenteService.GetList(false);
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

                _vehiculosRepository = GetList(false);
                /* Verifico si existe el automóvil en el repositorio */
                bool vehiculoEncontrado = false;
                int indexToRemove = -1;

                for (int i = 0; i < _vehiculosRepository.Count; i++)
                {
                    if (_vehiculosRepository[i].Patente == patente)
                    {
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

                    Console.Clear();
                    Console.WriteLine("\tAgencia de Automóviles");
                    Console.Write("\nAutomóvil retirado correactamente");
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
