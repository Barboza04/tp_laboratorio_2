using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException:Exception
    {
        static string mensajeBase = "DNI invalido";

        public string Message { get { return DniInvalidoException.mensajeBase;} }

        public DniInvalidoException()
            : base(mensajeBase)
        {

        }

        public DniInvalidoException(Exception e)
            : base(mensajeBase, e)
        {

        }

        public DniInvalidoException(string message)
            : this(message, null)
        {

        }

        public DniInvalidoException(string message, Exception e)
            : base(mensajeBase + message, e)
        {

        }
    }
}
