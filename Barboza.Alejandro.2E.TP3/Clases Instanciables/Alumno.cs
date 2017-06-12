using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        #region "Atributos"
        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoDeCuenta;
        #endregion

        public enum EEstadoCuenta { AlDia, Becado, Deudor }

        #region "Constructores"
        /// <summary>
        /// Inicializa la instancia con valores por defecto en sus atributos
        /// </summary>
        public Alumno()
        {
        }
        /// <summary>
        /// Inicializa la instancia con los valores recibidos por parametro
        /// </summary>
        /// <param name="legajo">Entero que representa el legajo del Alumno</param>
        /// <param name="nombre">Cadena que representa el nombre del Alumno</param>
        /// <param name="apellido">Cadena que representa el apellido del Alumno</param>
        /// <param name="dni">Cadena que representa el número de dni del Alumno</param>
        /// <param name="nacionalidad">Enumerado que indica si el Alumno es Argentino
        /// o Extranjero</param>
        /// <param name="claseQueToma">Enumerado que representa la clase a la que asiste
        /// el Alumno</param>
        public Alumno(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(legajo, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }
        /// <summary>
        /// Inicializa la instancia con los valores recibidos por parametro
        /// </summary>
        /// <param name="legajo">Entero que representa el legajo del Alumno</param>
        /// <param name="nombre">Cadena que representa el nombre del Alumno</param>
        /// <param name="apellido">Cadena que representa el apellido del Alumno</param>
        /// <param name="dni">Cadena que representa el número de dni del Alumno</param>
        /// <param name="nacionalidad">Enumerado que indica si la persona es Argentino
        /// o Extranjero</param>
        /// <param name="claseQueToma">Enumerado que representa la clase a la que asiste
        /// el Alumno</param>
        /// <param name="estadoDeCuenta">Enumerado que representa el estado de cuenta del Alumno</param>
        public Alumno(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoDeCuenta)
            : this(legajo, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoDeCuenta = estadoDeCuenta;
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Genera un StringBuilder y le carga los datos del Alumno
        /// </summary>
        /// <returns>Cadena con los datos del Alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendFormat("ESTADO DE CUENTA: {0}\n", this._estadoDeCuenta);
            sb.AppendFormat("{0}\n", this.ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// Retorna una cadena con un formato especifico, mostrando el valor
        /// del atributo _claseQueToma
        /// </summary>
        /// <returns>Cadena con el valor de _claseQueToma</returns>
        protected override string ParticiparEnClase()
        {
            return String.Format("TOMA CLASES DE {0}", this._claseQueToma);
        }
        /// <summary>
        /// Expone los datos del Alumno
        /// </summary>
        /// <returns>Cadena con los datos del Alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Determina si un Alumno puede participar en un EClases verificando
        /// su estado de cuenta y si está anotado en la clase.
        /// </summary>
        /// <param name="al">Instancia de Alumno</param>
        /// <param name="clase">Elemento de EClases</param>
        /// <returns>true si su estado de cuenta está al día y está inscripto
        /// en la clase</returns>
        public static bool operator ==(Alumno al, Universidad.EClases clase)
        {
            if (al._estadoDeCuenta != EEstadoCuenta.Deudor && al._claseQueToma == clase)
                return true;
            return false;
        }
        /// <summary>
        /// Determina si un alumno no toma un EClases en particular
        /// </summary>
        /// <param name="al">Instancia de Alumno</param>
        /// <param name="clase">Elemento de EClases</param>
        /// <returns>true si el Alumno toma dicha clase</returns>
        public static bool operator !=(Alumno al, Universidad.EClases clase)
        {
            if (al._claseQueToma != clase)
                return true;
            return false;
        }
        #endregion
    }
}
