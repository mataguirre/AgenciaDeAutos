using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaDeAutos
{
    public class VehiculoService
    {
        private readonly List<string> _patentesRepository = new List<string>();
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
        private Vehiculo _vehiculo = new Vehiculo();
        private readonly List<Vehiculo> _vehiculosRepository = new List<Vehiculo>();
        private readonly string _filePath = "Vehiculos.txt";
        public VehiculoService()
        {

        }
        public VehiculoService(string patente, decimal kilometros, int anio, int marcaId, string modelo, int segmentoId, int combustibleId, decimal precioVenta, string observaciones)
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

        public List<Vehiculo> GetList()
        {
            if (File.Exists(_filePath))
            {
                try
                {
                    /* Instancio la clase FileStream */
                    _file = new FileStream(_filePath, FileMode.Open);
                    /* Instancio la clase StreamReader */
                    _sr = new StreamReader(_file);
                    /* Recorro cada una de las líneas del archivo */
                    Console.Clear();
                    while (!_sr.EndOfStream)
                    {
                        string[] fields = _sr.ReadLine().Split(';');
                        Console.WriteLine("\tListado de Automóviles");
                        Console.WriteLine($"\nPatente: {fields[1]}");
                        Console.WriteLine($"Modelo: {fields[8]}");
                        Console.WriteLine($"Año: {fields[2]}");
                        Console.WriteLine($"Combustible: {fields[3]}");
                        Console.WriteLine($"Kilometros: {fields[4]}KM");
                        Console.WriteLine($"Segmento: {fields[5]}");
                        Console.WriteLine($"Precio de Venta: ${fields[6]}");
                        Console.Write($"Observaciones: {fields[7]}.");                
                    }

                    _vehiculo.Id = _id;
                    _vehiculo.Patente = _patente;
                    _vehiculo.Anio = _anio;
                    _vehiculo.CombustibleId = _combustibleId;
                    _vehiculo.Kilometros = _kilometros;
                    _vehiculo.SegmentoId = _segmentoId;
                    _vehiculo.PrecioVenta = _precioVenta;
                    _vehiculo.Observaciones = _observaciones;
                    _vehiculo.Modelo = _modelo;

                    _vehiculosRepository.Add(_vehiculo);

                    _sw.Close();
                    _file.Close();
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            } else
            {
                Console.Clear();
                Console.WriteLine("\tAgencia de Automóviles");
                Console.Write("\nAún no se ha creado el respositorio de los automóviles");
               
            }
            _sr.Close();
            _file.Close();
            Console.ReadKey();
            return _vehiculosRepository.ToList();
        }

        public void SetList()
        {
            Console.Clear();
            if(!File.Exists(_filePath))
            {
                try
                {
                    Console.WriteLine("\tAgencia de Automóviles");
                    /* Instancio la clase FileStream */
                    _file = new FileStream(_filePath, FileMode.Create);
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

                    _vehiculo.Id = _id;
                    _vehiculo.Patente = _patente;
                    _vehiculo.Anio = _anio;
                    _vehiculo.CombustibleId = _combustibleId;
                    _vehiculo.Kilometros = _kilometros;
                    _vehiculo.SegmentoId = _segmentoId;
                    _vehiculo.PrecioVenta = _precioVenta;
                    _vehiculo.Observaciones = _observaciones;
                    _vehiculo.Modelo = _modelo;

                    _patentesRepository.Add(_patente);
                    _vehiculosRepository.Add(_vehiculo);

                    _sw.WriteLine($"{_id};{_patente};{_anio};{_combustibleId};{_kilometros};{_segmentoId};{_precioVenta};{_observaciones};{_modelo}");

                    Console.Write("\nAutomóvil creado correctamente");
                } catch(Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            } else
            {
                try
                {
                    /* Instancio la clase FileStream */
                    _file = new FileStream(_filePath, FileMode.Append);
                    /* Instancio la clase StreamReader */
                    _sw = new StreamWriter(_file);
                    /* Asigno el ID */
                    _id = Guid.NewGuid();
                    /* Ingreso la patente */
                    Console.Write("Ingrese patente: ");
                    _patente = Console.ReadLine().ToLower();
                    /* Verifico que la patente no exista */
                    if(!_patentesRepository.Contains(_patente))
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

                        _vehiculo.Id = _id;
                        _vehiculo.Patente = _patente;
                        _vehiculo.Anio = _anio;
                        _vehiculo.CombustibleId = _combustibleId;
                        _vehiculo.Kilometros = _kilometros;
                        _vehiculo.SegmentoId = _segmentoId;
                        _vehiculo.PrecioVenta = _precioVenta;
                        _vehiculo.Observaciones = _observaciones;
                        _vehiculo.Modelo = _modelo;

                        _patentesRepository.Add(_patente);
                        _vehiculosRepository.Add(_vehiculo);

                        _sw.WriteLine($"{_id};{_patente};{_anio};{_combustibleId};{_kilometros};{_segmentoId};{_precioVenta};{_observaciones};{_modelo}");

                        Console.Write("\nAutomóvil agregado correctamente");

                        _sw.Close();
                        _file.Close();
                    }
                    Console.Clear();
                    Console.Write("Este automóvil ya fue previamente cargado");
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            }
            Console.ReadKey();
        }
        
        public void DeleteItem(string patente)
        {
            if (File.Exists(_filePath))
            {
                try
                {
                    /* Instancio la clase FileStream */
                    _file = new FileStream(_filePath, FileMode.Open);
                    /* Instancio la clase StreamReader */
                    _sr = new StreamReader(_file);
                    /* Guardo en una variable el automóvil */
                    Vehiculo vehiculo = this.GetList().FirstOrDefault(x => x.Patente == patente);
                    /* Verifico si existe el automóvil en el repositorio */
                    if (vehiculo.Patente != null)
                    {
                        /* Remuevo el elemento en la primera posición */
                        _sr.ReadLine().Remove(0, 1);
                        Console.Clear();
                        Console.WriteLine("\tAgencia de Automóviles");
                        Console.Write("\nAutomóvil removido correctamente");
                    } else
                    {
                        Console.Clear();
                        Console.WriteLine("El automóvil que desea eliminar no se encuentra en el repositorio");
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\tAgencia de Automóviles");
                Console.Write("\nAún no se ha creado el respositorio de los automóviles");
            }
            _sr.Close();
            _file.Close();
            Console.ReadKey();
        }
    }
}
