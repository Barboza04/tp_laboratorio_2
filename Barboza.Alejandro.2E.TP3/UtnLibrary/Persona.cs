using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtnLibrary
{
    public abstract class Persona
    {
        public enum ENacionalidad { Argentino, Extranjero}

        #region "Atributos"
        protected string _nombre;
        protected string _apellido;
        protected ENacionalidad _nacionalidad;
        protected int _dni;
        #endregion

        #region "Propiedades"
        /// <summary>
        /// 
        /// </summary>
        public string Nombre { get { return this._nombre; }
            set { this._nombre = this.ValidarNombreApellido(value); } }
        /// <summary>
        /// 
        /// </summary>
        public string Apellido { get { return this._apellido; }
            set { this._apellido = this.ValidarNombreApellido(value); } }
        /// <summary>
        /// 
        /// </summary>
        public ENacionalidad Nacionalidad { get { return this._nacionalidad; }
            set { this._nacionalidad = value; } }
        /// <summary>
        /// 
        /// </summary>
        public int Dni { get { return this._dni; }
            set { this._dni = this.ValidarDni(this.Nacionalidad, value); } }
        /// <summary>
        /// 
        /// </summary>
        public string StringToDni { set { this._dni = this.ValidarDni(this.Nacionalidad, value); } }
        #endregion

        #region "Constructores"
        public Persona()
        {
        }
        /// <summary>
        /// Inicializa una instancia de Persona con los datos recibidos por parametro
        /// </summary>
        /// <param name="nombre">cadena de caracteres que representa el nombre de la persona</param>
        /// <param name="apellido">cadena de caracteres que representa el apellido de la persona</param>
        /// <param name="nacionalidad">enumerado que indica si la persona es Argentino
        /// o Extranjero</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Inicializa una instancia de Persona con los datos recibidos por parametro
        /// </summary>
        /// <param name="nombre">cadena de caracteres que representa el nombre de la persona</param>
        /// <param name="apellido">cadena de caracteres que representa el apellido de la persona</param>
        /// <param name="dni">entero que representa el número de dni de la persona</param>
        /// <param name="nacionalidad">enumerado que indica si la persona es Argentino
        /// o Extranjero</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            :this(nombre,apellido,nacionalidad)
        {
            this.Dni = dni;
        }
        /// <summary>
        /// Inicializa una instancia de Persona con los datos recibidos por parametro
        /// </summary>
        /// <param name="nombre">cadena de caracteres que representa el nombre de la persona</param>
        /// <param name="apellido">cadena de caracteres que representa el apellido de la persona</param>
        /// <param name="dni">cadena de caracteres que representa el número de dni de la persona</param>
        /// <param name="nacionalidad">enumerado que indica si la persona es Argentino
        /// o Extranjero</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = dni;
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Valida que el dni este dentro del rango correspondiente segun la nacionalidad
        /// </summary>
        /// <param name="nacionalidad">enumerado que indica si la persona es Argentino
        /// o Extranjero</param>
        /// <param name="dni">entero que representa el número de dni de la persona</param>
        /// <returns>si puede validar retorna el dni, caso contrario lanza una excepcion</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dni)
        {
            if (nacionalidad == ENacionalidad.Argentino && dni > 0 && dni < 90000000)
                return dni;
            else if (nacionalidad == ENacionalidad.Extranjero && dni >= 90000000)
                return dni;
            throw new Exception();
        }
        /// <summary>
        /// Valida que el dni este dentro del rango correspondiente segun la nacionalidad
        /// </summary>
        /// <param name="nacionalidad">enumerado ENacionalidad que indica si la persona es Argentino
        /// o Extranjero</param>
        /// <param name="dni">cadena de caracteres que representa el número de dni de la persona</param>
        /// <returns>si puede validar retorna el dni, caso contrario lanza una excepcion</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dni)
        {
            int auxDni = 0;
            if (int.TryParse(dni, out auxDni))
            {
                return this.ValidarDni(nacionalidad, auxDni);
            }
            return auxDni;
        }
        /// <summary>
        /// Valida que la cadena recibida solo contenga letras
        /// </summary>
        /// <param name="dato">cadena de caracteres que se verificara</param>
        /// <returns>si puede validar retorna la cadena, caso contrario retorna una cadena vacia</returns>
        private string ValidarNombreApellido(string dato)
        {
            foreach (char letra in dato)
            {
                if (!Char.IsLetter(letra))
                    return "";
            }
            return dato;
        }
        /// <summary>
        /// Expone los datos de la persona
        /// </summary>
        /// <returns>una cadena de caracteres con los datos de la persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n",this.Nombre,this.Apellido);
            sb.AppendFormat("NACIONALIDAD: {0}\n", this.Nacionalidad);
            return sb.ToString();
        }
        #endregion
    }
}
