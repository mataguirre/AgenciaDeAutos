using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaDeAutos.Servicios
{
    internal class FileService
    {
        public FileService() { }

        public void DeleteList(string[] archivos)
        {
            int filesCount = archivos.Count();
            Console.Clear();
            Console.WriteLine("\tAgencia de Automóviles");
            Console.Write("\nDesea elminar todos los archivos listados? (s/n): ");
            if(Console.ReadLine().ToLower() == "s")
            {
                foreach (string archivo in archivos)
                {
                    if (File.Exists(archivo))
                    {
                        File.Delete(archivo);
                        filesCount--;
                    }
                }
                if(filesCount == 0)
                {
                    Console.Clear();
                    Console.WriteLine("\tAgencia de Automóviles");
                    Console.Write($"\nLos archivos se han borrado correctamente");
                    Console.ReadKey();
                } else
                {
                    Console.Clear();
                    Console.WriteLine("\tAgencia de Automóviles");
                    Console.Write($"\nLos archivos ya fueron previamente eliminados");
                    Console.ReadKey();
                }
            } else
            {
                Console.Clear();
                Console.WriteLine("\tAgencia de Automóviles");
                Console.Write("\nVolviendo al menú principal...");
                Console.ReadKey();
            }
        }
    }
}
