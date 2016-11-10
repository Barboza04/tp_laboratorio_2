using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstaciables
{
    public sealed class Alumno:PersonaGimnasio
    {

        #region Atributos
        private Gimnasio.EClases _claseQueToma;
        private EEstadoCuenta _estadoDeCuenta;
        #endregion

        #region Propiedades
        public Gimnasio.EClases ClaseQueToma { get { return this._claseQueToma;} }
        public EEstadoCuenta EstadoDeCuenta { get { return this._estadoDeCuenta;} }
        #endregion

        #region Enumerado
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            MesPrueba
        }
        #endregion

        #region Constructores
        public Alumno()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma)
            : base(id,nombre,apellido,dni,nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma,EEstadoCuenta estadoDeCuenta)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
            this._estadoDeCuenta = estadoDeCuenta;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Carga un Stringbuilder con un dato de la instancia
        /// </summary>
        /// <returns>Retorna el Stringbuilder</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("TOMA CLASES DE " + this._claseQueToma);
            return sb.ToString();
        }

        /// <summary>
        /// Carga un Stringbuilder con los datos de la instancia
        /// </summary>
        /// <returns>Retorna el Stringbuilder</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.AppendLine("ESTADO DE CUENTA: " + this._estadoDeCuenta);
            sb.Append(this.ParticiparEnClase());
 	        return sb.ToString();
        }

        /// <summary>
        /// Sobreescribe el metodo ToString
        /// </summary>
        /// <returns>Retorna una cadena con los datos de la instancia</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Compara un alumno y una clases segun los atributos del alumno
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Gimnasio.EClases a comparar</param>
        /// <returns>Retorna true si el alumno toma la clase y no es deudor, sino false</returns>
        public static bool operator ==(Alumno a, Gimnasio.EClases clase)
        {
            if ((a._claseQueToma == clase) && (a._estadoDeCuenta!=EEstadoCuenta.Deudor))
                return true;
            return false;
        }

        /// <summary>
        /// Compara un alumno y una clases a partir de la clase que toma el alumno
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Gimnasio.EClases a comparar</param>
        /// <returns>Retorna true si el alumno no toma la clase, sino fasle</returns>
        public static bool operator !=(Alumno a, Gimnasio.EClases clase)
        {
            bool value = false;
            if (a._claseQueToma != clase)
                value = true;
            return value;
        }
        #endregion

    }
}
