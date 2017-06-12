using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        private static string _message = "Error al generar el archivo.";

        public ArchivosException()
            : base(_message)
        {

        }
    }
}
