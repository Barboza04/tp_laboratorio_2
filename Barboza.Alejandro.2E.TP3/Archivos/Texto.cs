using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Genera un archivo de texto con los datos recibidos
        /// </summary>
        /// <param name="archivo">Ruta completa y nombre del archivo</param>
        /// <param name="datos">Cadena con los datos a guardar</param>
        /// <returns>true si pudo generar el archivo, sino lanza un Archivos Exception()</returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(archivo, true))
                {
                    file.WriteLine(datos);
                }
            }
            catch (Exception)
            {
                throw new ArchivosException();
            }
            return true;
        }
        /// <summary>
        /// Lee un archivo de texto y lo asigna al parametro de salida
        /// </summary>
        /// <param name="archivo">Archivo a ser leido</param>
        /// <param name="datos">Parametro de salida donde se guardara el valor de "archivo"</param>
        /// <returns>true si pudo leer el archivo, sino lanza un ArchivosException()</returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader(archivo))
                {
                    datos = file.ReadToEnd();
                }
            }
            catch (Exception)
            {
                datos = "";
                throw new ArchivosException();
            }
            return true;
        }
    }
}
