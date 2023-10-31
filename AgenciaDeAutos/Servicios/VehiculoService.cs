using AgenciaDeAutos.DTOs;
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
        private StreamReader _sr;
        private StreamWriter _sw;
        private FileStream _file;
        private List<Vehiculo> _vehiculosRepository = new List<Vehiculo>();
        private List<Combustible> _combustiblesRepository = new List<Combustible>()
        {
            new Combustible
            {
                Id = 1,
                Nombre = "Diesel"
            },
            new Combustible
            {
                Id = 2,
                Nombre = "Nafta"
            },
            new Combustible
            {
                Id = 3,
                Nombre = "Gas"
            },
            new Combustible
            {
                Id = 4,
                Nombre = "Gasoil"
            }
        };
        private List<Segmento> _segmentosRepository = new List<Segmento>()
        {
            new Segmento()
            {
                Id = 1,
                Nombre = "Sedan"
            },
            new Segmento()
            {
                Id = 2,
                Nombre = "Coupe"
            },
            new Segmento()
            {
                Id = 3,
                Nombre = "Scooter"
            },
            new Segmento()
            {
                Id = 4,
                Nombre = "Rutera"
            }
        };
        private List<Marca> _marcasRepository = new List<Marca>()
        {
            new Marca()
            {
                Id = 1,
                Nombre = "Chevrolet"
            },
            new Marca()
            {
                Id = 2,
                Nombre = "Peugeot"
            },
             new Marca()
            {
                Id = 3,
                Nombre = "Nissan"
            }
        };
        private readonly string _vehiculosFilePath = "Vehiculos.txt";

        public VehiculoService()
        {
            CargarDatos();
        }

        public void CargarDatos()
        {
            if (File.Exists(_vehiculosFilePath))
            {
                _file = new FileStream(_vehiculosFilePath, FileMode.Open);
                _sr = new StreamReader(_file);
                while (!_sr.EndOfStream)
                {
                    string[] fields = _sr.ReadLine().Split(';');

                    Vehiculo _vehiculo = new Vehiculo();
                    _vehiculo.Id = int.Parse(fields[0]);
                    _vehiculo.Patente = fields[1];
                    _vehiculo.Anio = int.Parse(fields[2]);
                    _vehiculo.MarcaId = int.Parse(fields[3]);
                    _vehiculo.CombustibleId = int.Parse(fields[4]);
                    _vehiculo.Kilometros = decimal.Parse(fields[5]);
                    _vehiculo.SegmentoId = int.Parse(fields[6]);
                    _vehiculo.PrecioVenta = decimal.Parse(fields[7]);
                    _vehiculo.Observaciones = fields[8];
                    _vehiculo.Modelo = fields[9];
                    _vehiculo.Color = fields[10];

                    if (!_vehiculosRepository.Any(x => x.Patente == _vehiculo.Patente || x.Id == _vehiculo.Id))
                    {
                        _vehiculosRepository.Add(_vehiculo);
                    }
                }
                _sr.Close();
                _file.Close();
            }
            else
            {
                _file = new FileStream(_vehiculosFilePath, FileMode.Create);
                GetVehicles();
                _file.Close();

            }
        }
        public List<VehiculoDto> GetVehicles()
        {
            if (File.Exists(_vehiculosFilePath))
            {
                var query = from vehicle in _vehiculosRepository
                            join combustible in _combustiblesRepository
                                on vehicle.CombustibleId equals combustible.Id
                            join segmento in _segmentosRepository
                                on vehicle.SegmentoId equals segmento.Id
                            join marca in _marcasRepository
                                on vehicle.MarcaId equals marca.Id
                            select new { vehicle, segmento, marca, combustible };

                var results = query.ToList();

                var vehiculosDto = results.Select(result => new VehiculoDto()
                {
                    Anio = result.vehicle.Anio,
                    Observaciones = result.vehicle.Observaciones,
                    Color = result.vehicle.Color,
                    Kilometros = result.vehicle.Kilometros,
                    Modelo = result.vehicle.Modelo,
                    Patente = result.vehicle.Patente,
                    PrecioVenta = result.vehicle.PrecioVenta,
                    Segmento = result.segmento.Nombre,
                    Marca = result.marca.Nombre,
                    Combustible = result.combustible.Nombre
                }).ToList();

                return vehiculosDto;
            } else
            {
                return new List<VehiculoDto>();
            }
        }

        public void CreateVehicle(CreateUpdateVehiculoDto input)
        {
            if (File.Exists(_vehiculosFilePath))
            {
                _file = new FileStream(_vehiculosFilePath, FileMode.Open);
                _sw = new StreamWriter(_file);
                Vehiculo _vehiculo = new Vehiculo();
                Random random = new Random();
                _vehiculo.Id = random.Next();
                _vehiculo.Patente = input.Patente;
                _vehiculo.Anio = input.Anio;
                _vehiculo.MarcaId = input.MarcadId;
                _vehiculo.CombustibleId = input.CombustibleId;
                _vehiculo.Kilometros = input.Kilometros;
                _vehiculo.SegmentoId = input.SegmentoId;
                _vehiculo.PrecioVenta = input.PrecioVenta;
                _vehiculo.Observaciones = input.Observaciones;
                _vehiculo.Modelo = input.Modelo;
                _vehiculo.Color = input.Color;

                if (!_vehiculosRepository.Any(x => x.Patente == input.Patente))
                {
                    _vehiculosRepository.Add(_vehiculo);

                    _sw.WriteLine(
                        $"{_vehiculo.Id};{_vehiculo.Patente};{_vehiculo.Anio};{_vehiculo.MarcaId};{_vehiculo.CombustibleId};{_vehiculo.Kilometros};{_vehiculo.SegmentoId};{_vehiculo.PrecioVenta};{_vehiculo.Observaciones};{_vehiculo.Modelo};{_vehiculo.Color}"
                    );
                };

                _sw.Close();
                _file.Close();
            }
        }

        public void UpdateVehicle(CreateUpdateVehiculoDto input)
        {
            if (File.Exists(_vehiculosFilePath))
            {
                Vehiculo _vehiculoAEditar = _vehiculosRepository.FirstOrDefault(x => x.Patente == input.Patente);
                var _vehicleIndex = _vehiculosRepository.IndexOf(_vehiculoAEditar);

                if (_vehiculoAEditar != null)
                {
                    _vehiculoAEditar.PrecioVenta = input?.PrecioVenta != null ? input.PrecioVenta : _vehiculoAEditar.PrecioVenta;
                    _vehiculoAEditar.Color = input?.Color != null ? input.Color : _vehiculoAEditar.Color;
                    _vehiculoAEditar.CombustibleId = input?.CombustibleId != 0 ? input.CombustibleId : _vehiculoAEditar.CombustibleId;
                    _vehiculoAEditar.Modelo = input?.Modelo != null ? input.Modelo : _vehiculoAEditar.Modelo;
                    _vehiculoAEditar.MarcaId = input?.MarcadId != 0 ? input.MarcadId : _vehiculoAEditar.MarcaId;
                    _vehiculoAEditar.SegmentoId = input?.SegmentoId != 0 ? input.SegmentoId : _vehiculoAEditar.SegmentoId;
                    _vehiculoAEditar.Anio = input?.Anio != 0 ? input.Anio : _vehiculoAEditar.Anio;
                    _vehiculoAEditar.Kilometros = input?.Kilometros != 0 ? input.Kilometros : _vehiculoAEditar.Kilometros;
                    _vehiculoAEditar.Observaciones = input?.Observaciones != null ? input.Observaciones : _vehiculoAEditar.Observaciones;

                    _vehiculosRepository[_vehicleIndex] = _vehiculoAEditar;

                    List<string> vehiculos = File.ReadAllLines(_vehiculosFilePath).ToList();
                    File.WriteAllLines(_vehiculosFilePath, vehiculos);
                }
            }
        }

        public void DeleteVehicle(string patente)
        {
            if (File.Exists(_vehiculosFilePath))
            {
                Vehiculo _vehiculoARemover = _vehiculosRepository.FirstOrDefault(x => x.Patente == patente);
                int _vehicleIndex = _vehiculosRepository.IndexOf(_vehiculoARemover);

                if (_vehiculoARemover != null)
                {
                    List<string> vehiculos = File.ReadAllLines(_vehiculosFilePath).ToList();
                    vehiculos.RemoveAt(_vehicleIndex);
                    /*File.WriteAllLines(_vehiculosFilePath, vehiculos);*/
                    /*_vehiculosRepository.Remove(_vehiculoARemover);*/
                    _vehiculosRepository.Clear();
                    CargarDatos();
                }
            }
        }
    }
}
