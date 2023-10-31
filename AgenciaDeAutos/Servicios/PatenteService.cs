using AgenciaDeAutos.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaDeAutos.Servicios
{
    public class PatenteService
    {
        /* private readonly string _filePath = "Patentes.txt";
         private StreamReader _sr;
         private StreamWriter _sw;
         private FileStream _file;
         private List<Patente> _patentesRepository = new List<Patente>();
         private bool onInit = true;
         private int _patentesCount;
         int anchoTotal = 50;
         public PatenteService()
         {
             _patentesRepository = GetList(false);
         }
         public List<Patente> GetList(bool info = true)
         {
             if (File.Exists(_filePath))
             {
                 if (info)
                 {
                     Console.Clear();
                     // Imprimir la parte superior de la tabla
                     Console.WriteLine("\tListado de Herramientas\n");
                     Console.WriteLine(new string('-', anchoTotal));
                     Console.WriteLine($"| {"Id",-36} | {"Nombre",-7} |");
                     Console.WriteLine(new string('-', anchoTotal));
                 }
                 _file = new FileStream(_filePath, FileMode.Open);
                 _sr = new StreamReader(_file);
                 if (_patentesRepository.Count() == 0 && onInit)
                 {
                     if (!_sr.EndOfStream)
                     {
                         _patentesCount = 0;
                         while (!_sr.EndOfStream)
                         {
                             string[] fields = _sr.ReadLine().Split(';');

                             if (info)
                             {
                                 Console.WriteLine(
                                     $"| {fields[0],-20} | {fields[1],-7} |"
                                 );
                                 Console.WriteLine(new string('-', anchoTotal));
                             }

                             Patente _patente = new Patente(); // Crear una nueva instancia de Patente para cada línea

                             _patente.Id = Guid.Parse(fields[0]);
                             _patente.Nombre = fields[1];

                             _patentesRepository.Add(_patente);
                             _patentesCount++;
                         }
                         if (info)
                         {
                             Console.Write($"\nCantidad de patentes: {_patentesCount}");
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
                             Console.Write("\nAún no se ingresaron patentes");
                             Console.ReadKey();
                         }
                     }
                 }
                 else
                 {
                     _patentesCount = 0;
                     while (!_sr.EndOfStream)
                     {
                         string[] fields = _sr.ReadLine().Split(';');

                         if (info)
                         {
                             Console.WriteLine(
                                     $"| {fields[0],-20} | {fields[1],-7} |"
                                 );
                             Console.WriteLine(new string('-', anchoTotal));
                         }
                         _patentesCount++;
                     }
                     if (info)
                     {
                         Console.Write($"\nCantidad de patentes: {_patentesCount}");
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
             return _patentesRepository;
         }
         public void SetList(string nuevaPatente)
         {
             if (!File.Exists(_filePath))
             {
                 _file = new FileStream(_filePath, FileMode.Create);
                 _sw = new StreamWriter(_file);

                 Patente _patente = new Patente();
                 _patente.Id = Guid.NewGuid();
                 _patente.Nombre = nuevaPatente;
                 _sw.WriteLine($"{_patente.Id};{_patente.Nombre}");
                 _patentesRepository.Add(_patente);

                 _sw.Close();
                 _file.Close();
             }
             else
             {
                 _file = new FileStream(_filePath, FileMode.Append);
                 _sw = new StreamWriter(_file);

                 if (!_patentesRepository.Any(x => x.Nombre == nuevaPatente))
                 {
                     Patente _patente = new Patente();
                     _patente.Id = Guid.NewGuid();
                     _patente.Nombre = nuevaPatente;
                     _sw.WriteLine($"{_patente.Id};{_patente.Nombre}");
                     _patentesRepository.Add(_patente);
                 }

                 _sw.Close();
                 _file.Close();
             }
         }
         public void DeleteItem(string viejaPatente, bool info = true)
         {
             if (File.Exists(_filePath))
             {
                 Patente _patenteARemover = new Patente();
                 *//* Verifico si existe el automóvil en el repositorio *//*
                 bool patenteEncontrada = false;
                 int indexToRemove = -1;

                 for (int i = 0; i < _patentesRepository.Count; i++)
                 {
                     if (_patentesRepository[i].Nombre == viejaPatente)
                     {
                         _patenteARemover = _patentesRepository[i];
                         patenteEncontrada = true;
                         indexToRemove = i;
                         break;
                     }
                 }

                 if (patenteEncontrada)
                 {
                     *//* Leer todas las líneas del archivo excepto la que se va a eliminar *//*
                     List<string> patentes = File.ReadAllLines(_filePath).ToList();
                     patentes.RemoveAt(indexToRemove); // Eliminar la línea correspondiente al vehículo
                     *//* Escribir las líneas actualizadas en el archivo *//*
                     File.WriteAllLines(_filePath, patentes);
                     _patentesRepository.Remove(_patenteARemover);

                     if (info)
                     {
                         Console.Clear();
                         Console.WriteLine("\tAgencia de Automóviles");
                         Console.Write("\nPatente retirada correctamente");
                         Console.ReadKey();
                     }
                 }
                 else
                 {
                     if (info)
                     {
                         Console.Clear();
                         Console.WriteLine("\tAgencia de Automóviles");
                         Console.Write(
                             "\nLa patente que desea remover no se encuentra en la concesionaria"
                         );
                         Console.ReadKey();
                     }
                 }
             }
             else
             {
                 Console.Clear();
                 Console.WriteLine("\tAgencia de Automóviles");
                 Console.Write("\nConcesionaria inhabilitada por el momento");
                 Console.ReadKey();
             }
         }*/
    }
}
