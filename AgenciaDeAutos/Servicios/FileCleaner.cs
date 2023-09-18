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
        public FileCleaner()
        {

        }

        public void DeleteFile(string filePathToDelete, bool info = true)
        {
            if (File.Exists(filePathToDelete))
            {
                File.Delete(filePathToDelete);
                if (info)
                {
                    Console.Clear();
                    Console.Write($"Archivo {filePathToDelete} borrado correctamente");
                    Console.ReadKey();
                }
            }
            else
            {
                if (info)
                {
                    Console.Clear();
                    Console.Write("El archivo que intenta borrar es inexistente");
                    Console.ReadKey();

                }
            }
        }
    }
}
