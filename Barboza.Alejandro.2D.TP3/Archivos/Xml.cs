using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T>:IArchivo<T>
    {

        /// <summary>
        /// Genera un archivo xml con los datos recibidos
        /// </summary>
        /// <param name="archivo">Nombre y ruta del archivo</param>
        /// <param name="datos">Datos a guardar en xml</param>
        /// <returns>Retorna true si pudo generar el archivo, sino lanza una excepcion</returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                StreamWriter writer = new StreamWriter(archivo);
                serializer.Serialize(writer, datos);
                writer.Close();

                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Lee un archivo xml y lo guarda en el parametro out
        /// </summary>
        /// <param name="archivo">Archivo a ser leido</param>
        /// <param name="datos">Parametro donde se guardan los datos</param>
        /// <returns>Retorna true si pudo leer el archivo, sino false e imprime el mensaje de la excepcion</returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                TextReader writer = new StreamReader(archivo);
                datos = (T)serializer.Deserialize(writer);
                writer.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                datos = default(T);
                return false;
            }
        }
    }
}
