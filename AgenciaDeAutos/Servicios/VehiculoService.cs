using AgenciaDeAutos.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
                Id = Guid.Parse("281c357b-f9c5-4449-9610-04a30557e455"),
                Nombre = "Diesel"
            },
            new Combustible
            {
                Id = Guid.Parse("cdc87a28-79c1-4f1e-9237-0fa6a47806ec"),
                Nombre = "Nafta"
            },
            new Combustible
            {
                Id = Guid.Parse("a63f4ccc-9f23-46b4-9450-661e3d77c835"),
                Nombre = "Gas"
            },
            new Combustible
            {
                Id = Guid.Parse("2fb22736-6ac4-4c5f-a846-ebb65eecccf1"),
                Nombre = "Gasoil"
            }
        };

        private List<Segmento> _segmentosRepository = new List<Segmento>()
        {
            new Segmento()
            {
                Id = Guid.Parse("922897ab-fe9d-439f-ab61-939a77811610"),
                Nombre = "Sedan"
            },
            new Segmento()
            {
                Id = Guid.Parse("0b225d69-d729-4659-a6c6-14e03be192fd"),
                Nombre = "Coupe"
            },
            new Segmento()
            {
                Id = Guid.Parse("9f13f0c8-cc77-4ebf-9684-7bddd8006bd9"),
                Nombre = "Scooter"
            },
            new Segmento()
            {
                Id = Guid.Parse("f448e1e3-6b53-48f2-a257-985af9d789a9"),
                Nombre = "Rutera"
            }
        };

        private List<Marca> _marcasRepository = new List<Marca>()
        {
            new Marca()
            {
                Id = Guid.Parse("f451a5a4-b036-487f-a10d-e87804d93c04"),
                Nombre = "Chevrolet"
            },
            new Marca()
            {
                Id = Guid.Parse("322f7e5f-5e9a-4290-a7d3-a2556ce5460d"),
                Nombre = "Peugeot"
            },
             new Marca()
            {
                Id = Guid.Parse("59e3c1f2-d42c-4d39-8888-ed16279ee871"),
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
                    _vehiculo.Id = Guid.Parse(fields[0]);
                    _vehiculo.Patente = fields[1];
                    _vehiculo.Anio = int.Parse(fields[2]);
                    _vehiculo.MarcaId = Guid.Parse(fields[3]);
                    _vehiculo.CombustibleId = Guid.Parse(fields[4]);
                    _vehiculo.Kilometros = decimal.Parse(fields[5]);
                    _vehiculo.SegmentoId = Guid.Parse(fields[6]);
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
                _file.Close();
            }
        }

        public List<VehiculoDto> GetVehicles()
        {
            CargarDatos();
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
            CargarDatos();
            if (File.Exists(_vehiculosFilePath))
            {
                _file = new FileStream(_vehiculosFilePath, FileMode.Append);
                _sw = new StreamWriter(_file);
                Vehiculo _vehiculo = new Vehiculo();
                _vehiculo.Id = Guid.NewGuid();
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
            CargarDatos();
            if (File.Exists(_vehiculosFilePath))
            {
                _file = new FileStream(_vehiculosFilePath, FileMode.Open);
                _sw = new StreamWriter(_file);
                Vehiculo _vehiculoAEditar = _vehiculosRepository.FirstOrDefault(x => x.Patente == input.Patente);
                var _vehicleIndex = _vehiculosRepository.IndexOf(_vehiculoAEditar);
                if (_vehiculoAEditar != null)
                {
                    _vehiculoAEditar.PrecioVenta = input?.PrecioVenta != null ? input.PrecioVenta : _vehiculoAEditar.PrecioVenta;
                    _vehiculoAEditar.Color = input?.Color != null ? input.Color : _vehiculoAEditar.Color;
                    _vehiculoAEditar.CombustibleId = input?.CombustibleId != null ? input.CombustibleId : _vehiculoAEditar.CombustibleId;
                    _vehiculoAEditar.Modelo = input?.Modelo != null ? input.Modelo : _vehiculoAEditar.Modelo;
                    _vehiculoAEditar.MarcaId = input?.MarcadId != null ? input.MarcadId : _vehiculoAEditar.MarcaId;
                    _vehiculoAEditar.SegmentoId = input?.SegmentoId != null ? input.SegmentoId : _vehiculoAEditar.SegmentoId;
                    _vehiculoAEditar.Anio = input?.Anio != 0 ? input.Anio : _vehiculoAEditar.Anio;
                    _vehiculoAEditar.Kilometros = input?.Kilometros != 0 ? input.Kilometros : _vehiculoAEditar.Kilometros;
                    _vehiculoAEditar.Observaciones = input?.Observaciones != null ? input.Observaciones : _vehiculoAEditar.Observaciones;
                    List<string> lines = File.ReadAllLines(_vehiculosFilePath).ToList();
                    lines[_vehicleIndex] = $"{_vehiculoAEditar.Id};{_vehiculoAEditar.Patente};{_vehiculoAEditar.Anio};{_vehiculoAEditar.MarcaId};{_vehiculoAEditar.CombustibleId};{_vehiculoAEditar.Kilometros};{_vehiculoAEditar.SegmentoId};{_vehiculoAEditar.PrecioVenta};{_vehiculoAEditar.Observaciones};{_vehiculoAEditar.Modelo};{_vehiculoAEditar.Color}";
                    _vehiculosRepository.Insert(_vehicleIndex, _vehiculoAEditar);
                }
                _sw.Close();
                _file.Close();
            }
        }

        public void DeleteVehicle(string patente)
        {
            CargarDatos();
            if (File.Exists(_vehiculosFilePath))
            {
                var lineToRemove = "";
                List<string> lines = File.ReadAllLines(_vehiculosFilePath).ToList();

                foreach (string line in lines)
                {
                    string[] fields = line.Split(';');
                    if (fields[1].Contains(patente))
                    {
                        lineToRemove = line;
                    }
                }
                Vehiculo _vehiculoARemover = _vehiculosRepository.FirstOrDefault(x => x.Patente == patente);
                if (lineToRemove != null && lineToRemove != "")
                {
                    lines.Remove(lineToRemove);
                    File.WriteAllLines(_vehiculosFilePath, lines);
                    _vehiculosRepository.Remove(_vehiculoARemover);
                }
            }
        }
    }
}
