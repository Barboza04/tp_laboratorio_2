using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EntidadesAbstractas;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {

        /// <summary>
        /// Genera un archivo de texto con los datos recibidos
        /// </summary>
        /// <param name="archivo">Nombre y ruta del archivo</param>
        /// <param name="datos">Cadena con los datos a guardar</param>
        /// <returns>Retorna true si pudo generar el archivo, sino lanza una excepcion</returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter file = new System.IO.StreamWriter(archivo, false))
                {
                    file.WriteLine(datos);
                }
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Lee un archivo de texto y lo guarda en el parametro out
        /// </summary>
        /// <param name="archivo">Archivo a ser leido</param>
        /// <param name="datos">Parametro donde se guarda el texto</param>
        /// <returns>Retorna true si pudo leer el archivo, sino false e imprime el mensaje de la excepcion</returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using (StreamReader file = new StreamReader(archivo))
                {
                    datos = file.ReadToEnd();
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                datos = "";
                return false;
            }
        }
    }
}
