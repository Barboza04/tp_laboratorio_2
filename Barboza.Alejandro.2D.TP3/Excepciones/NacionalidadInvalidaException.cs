using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException:Exception
    {
        private string _message = "La nacionalidad no se condice con el número de DNI";

        public string Message { get { return this._message;} }

        public NacionalidadInvalidaException():base()
        {

        }

        public NacionalidadInvalidaException(string message):base(message)
        {

        }
    }
}
