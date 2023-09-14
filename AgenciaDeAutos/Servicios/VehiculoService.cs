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
        private StreamReader _sr = new StreamReader();
        private StreamWriter _sw = new StreamWriter();
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
            return _vehiculosRepository.ToList();
        }

        public void SetList()
        {
            if(!File.Exists(_filePath))
            {
                _file = new FileStream(_filePath, FileMode.Create);
                /* Asigno el ID */
                _id = Guid.NewGuid();
                /* Ingreso la patente */
                Console.Write("Ingrese patente: ");
                _patente = Console.ReadLine();
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

                _vehiculosRepository.Add(_vehiculo);

                _sw.WriteLine($"{_id};{_patente};{_anio};{_combustibleId};{_kilometros};{_segmentoId};{_precioVenta};{_observaciones};{_modelo}");

                _file.Close();
                _sw.Close();
            } else
            {
                _file = new FileStream(_filePath, FileMode.Append);
                /* Asigno el ID */
                _id = Guid.NewGuid();
                /* Ingreso la patente */
                Console.WriteLine("Ingrese patente: ");
                _patente = Console.ReadLine();
                /* Ingreso kilometros */
                Console.WriteLine("Ingrese kilometros: ");
                _kilometros = decimal.Parse(Console.ReadLine());
                /* Ingreso año */
                Console.WriteLine("Ingrese año: ");
                _anio = int.Parse(Console.ReadLine());
                /* Ingrese ID de marca */
                Console.WriteLine("Ingrese ID de marca: ");
                _marcaId = int.Parse(Console.ReadLine());
                /* Ingreso modelo */
                Console.WriteLine("Ingrese modelo: ");
                _modelo = Console.ReadLine();
                /* Ingreso ID de segmento */
                Console.WriteLine("Ingrese ID de segmento: ");
                _segmentoId = int.Parse(Console.ReadLine());
                /* Ingreso ID de combustible */
                Console.WriteLine("Ingrese ID de combustible: ");
                _combustibleId = int.Parse(Console.ReadLine());
                /* Ingreso precio de venta */
                Console.WriteLine("Ingrese precio de venta: $");
                _precioVenta = decimal.Parse(Console.ReadLine());
                /* Ingreso observaciones */
                Console.WriteLine("Ingrese observaciones: ");
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

                _vehiculosRepository.Add(_vehiculo);

                _sw.WriteLine($"{_id};{_patente};{_anio};{_combustibleId};{_kilometros};{_segmentoId};{_precioVenta};{_observaciones};{_modelo}");

                _file.Close();
                _sw.Close();
            }
        }
    }
}
