using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaDeAutos.Servicios
{
    public class FileCleaner
    {
        public FileCleaner() { }

        public void DeleteFiles(string[] filesPathToDelete, bool info = true)
        {
            foreach (string file in filesPathToDelete)
            {
                if (File.Exists(file))
                {
                    File.Delete(file);
                    if (info)
                    {
                        Console.Clear();
                        Console.WriteLine("\tAgencia de Automóviles");
                        Console.Write($"\nArchivo {file} borrado correctamente");
                        Console.ReadKey();
                    }
                }
                else
                {
                    if (info)
                    {
                        Console.Clear();
                        Console.WriteLine("\tAgencia de Automóviles");
                        Console.Write($"\nEl archivo {file} que intenta borrar es inexistente");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}
