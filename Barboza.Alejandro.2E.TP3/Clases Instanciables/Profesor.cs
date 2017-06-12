using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        #region "Atributos"
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Inicializa la instancia con valores por defecto en sus atributos
        /// </summary>
        public Profesor()
        {
        }
        /// <summary>
        /// Inicializa el atributo estatico random
        /// </summary>
        static Profesor()
        {
            _random = new Random();
        }
        /// <summary>
        /// Inicializa la instancia con los valores recibidos por parametro
        /// </summary>
        /// <param name="legajo">Entero que representa el legajo del Profesor</param>
        /// <param name="nombre">Cadena que representa el nombre del</param>
        /// <param name="apellido">Cadena que representa el apellido del Profesor</param>
        /// <param name="dni">Cadena que representa el número de dni del Profesor</param>
        /// <param name="nacionalidad">Enumerado que indica si el Profesor es Argentino
        /// o Extranjero</param>
        public Profesor(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(legajo, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Carga aleatoriamente dos EClases en el atributo de clases
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
                this._clasesDelDia.Enqueue(((Universidad.EClases)_random.Next(0, 4)));
        }
        /// <summary>
        /// Genera un StringBuilder y le carga los datos del Profesor
        /// </summary>
        /// <returns>Cadena con los datos del Profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// Retorna una cadena con un formato especifico, mostrando los valores
        /// del atributo _clasesDelDia
        /// </summary>
        /// <returns>Cadena con los valores del atributo _clasesDelDia</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA:");
            foreach (Universidad.EClases c in this._clasesDelDia)
            {
                sb.AppendLine(c.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// Determina si un Profesor imparte un EClases especifico
        /// </summary>
        /// <param name="p">Instancia de Profesor</param>
        /// <param name="clase">Elemento de EClases</param>
        /// <returns>true si el Profesor imparte la clase</returns>
        public static bool operator ==(Profesor p, Universidad.EClases clase)
        {
            foreach (Universidad.EClases c in p._clasesDelDia)
            {
                if(c == clase)
                    return true;
            }       
            return false;
        }
        /// <summary>
        /// Determina si un Profesor no imparte un EClases especifico
        /// </summary>
        /// <param name="p">Instancia de Profesor</param>
        /// <param name="clase">Elemento de EClases</param>
        /// <returns>true si el Profesor no imparte la clase</returns>
        public static bool operator !=(Profesor p, Universidad.EClases clase)
        {
            return !(p == clase);
        }
        /// <summary>
        /// Expone los datos del Profesor
        /// </summary>
        /// <returns>Cadena con los datos del Profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
