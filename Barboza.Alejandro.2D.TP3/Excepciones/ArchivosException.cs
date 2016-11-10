using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException:Exception
    {
        private string _message = "Error al generar el archivo.";

        public string Message { get { return this._message + "\n" + InnerException.Message; } }

        public ArchivosException(Exception innerException):base(innerException.Message,innerException)
        {

        }
    }
}
