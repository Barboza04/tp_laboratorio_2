using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException:Exception
    {
        private string _message = "Alumno repetido.";

        public string Message { get { return this._message;} }

        public AlumnoRepetidoException():base()
        {

        }
    }
}
