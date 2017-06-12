using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int _legajo;

        #region "Constructores"
        /// <summary>
        /// Inicializa la instancia con valores por defecto en sus atributos
        /// </summary>
        public Universitario()
        {
        }
        /// <summary>
        /// Inicializa la instancia con los valores recibidos por parametro
        /// </summary>
        /// <param name="legajo">Entero que representa el número de legajo</param>
        /// <param name="nombre">Cadena de caracteres que representa el nombre de la persona</param>
        /// <param name="apellido">Cadena de caracteres que representa el apellido de la persona</param>
        /// <param name="dni">Cadena de caracteres que representa el número de dni de la persona</param>
        /// <param name="nacionalidad">Enumerado que indica si la persona es Argentino
        /// o Extranjero</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Genera un StringBuilder y le carga los datos de la instancia
        /// </summary>
        /// <returns>String con los datos del Universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendFormat("LEGAJO NÚMERO: {0}\n", this._legajo);
            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Determina si el objeto recibido es de la misma clase que la instancia
        /// actual.
        /// </summary>
        /// <param name="obj">Objeto con quien se quiere comparar la clase</param>
        /// <returns>true si son de la misma clase</returns>
        public override bool Equals(object obj)
        {
            return this.GetType() == obj.GetType();
        }
        /// <summary>
        /// Determina si dos universitarios son iguales comparando tipo,
        /// legajo y dni.
        /// </summary>
        /// <param name="un1">Instancia de Universitario</param>
        /// <param name="un2">Instancia de Universitario</param>
        /// <returns>true si todas las comparaciones son verdaderas</returns>
        public static bool operator ==(Universitario un1, Universitario un2)
        {
            if (un1.Equals(un2) && (un1._legajo == un2._legajo || un1.Dni == un2.Dni))
                return true;
            return false;
        }
        /// <summary>
        /// Determina si dos universitarios son distintos comparando tipo,
        /// legajo y dni.
        /// </summary>
        /// <param name="un1">Instancia de Universitario</param>
        /// <param name="un2">Instancia de Universitario</param>
        /// <returns>true si todas las comparaciones son verdaderas</returns>
        public static bool operator !=(Universitario un1, Universitario un2)
        {
            return !(un1 == un2);
        }
        #endregion
    }
}
