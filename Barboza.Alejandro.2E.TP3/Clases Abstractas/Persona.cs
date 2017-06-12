using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public class Persona
    {
        #region "Atributos"
        private string _nombre;
        private string _apellido;
        private ENacionalidad _nacionalidad;
        private int _dni;
        #endregion

        public enum ENacionalidad { Argentino, Extranjero }

        #region "Propiedades"
        /// <summary>
        /// Retorna o inicializa el valor del atributo nombre
        /// </summary>
        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = this.ValidarNombreApellido(value); }
        }
        /// <summary>
        /// Retorna o inicializa el valor del atributo apellido
        /// </summary>
        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = this.ValidarNombreApellido(value); }
        }
        /// <summary>
        /// Retorna o inicializa el valor del atributo nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }
        /// <summary>
        /// Retorna o inicializa el valor del atributo dni
        /// </summary>
        public int Dni
        {
            get { return this._dni; }
            set { this._dni = this.ValidarDni(this.Nacionalidad, value); }
        }
        /// <summary>
        /// Inicializa el valor del atributo dni a partir de una cadena de caracteres
        /// </summary>
        public string StringToDni { set { this._dni = this.ValidarDni(this.Nacionalidad, value); } }
        #endregion

        #region "Constructores"
        /// <summary>
        /// Inicializa la instancia con valores por defecto en sus atributos
        /// </summary>
        public Persona()
        {
        }
        /// <summary>
        /// Inicializa la instancia con los datos recibidos por parametro
        /// </summary>
        /// <param name="nombre">Cadena de caracteres que representa el nombre de la persona</param>
        /// <param name="apellido">Cadena de caracteres que representa el apellido de la persona</param>
        /// <param name="nacionalidad">Enumerado que indica si la persona es Argentino
        /// o Extranjero</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Inicializa la instancia con los datos recibidos por parametro
        /// </summary>
        /// <param name="nombre">Cadena de caracteres que representa el nombre de la persona</param>
        /// <param name="apellido">Cadena de caracteres que representa el apellido de la persona</param>
        /// <param name="dni">Entero que representa el número de dni de la persona</param>
        /// <param name="nacionalidad">Enumerado que indica si la persona es Argentino
        /// o Extranjero</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.Dni = dni;
        }
        /// <summary>
        /// Inicializa la instancia con los datos recibidos por parametro
        /// </summary>
        /// <param name="nombre">Cadena de caracteres que representa el nombre de la persona</param>
        /// <param name="apellido">Cadena de caracteres que representa el apellido de la persona</param>
        /// <param name="dni">Cadena de caracteres que representa el número de dni de la persona</param>
        /// <param name="nacionalidad">Enumerado que indica si la persona es Argentino
        /// o Extranjero</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
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
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dni < 1 || dni > 89999999)
                        throw new NacionalidadInvalidaException();
                    break;
                case ENacionalidad.Extranjero:
                    if (dni < 89999999 || dni > 99999999)
                        throw new NacionalidadInvalidaException();
                    break;
            }
            return dni;
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
            if (dni != null)
            {
                if (!int.TryParse(dni, out auxDni))
                    throw new DniInvalidoException();
                return this.ValidarDni(nacionalidad, auxDni);
            }
            throw new DniInvalidoException();
        }
        /// <summary>
        /// Valida que la cadena recibida solo contenga letras
        /// </summary>
        /// <param name="dato">cadena de caracteres que se verificara</param>
        /// <returns>si puede validar retorna la cadena, caso contrario retorna una cadena vacia</returns>
        private string ValidarNombreApellido(string dato)
        {
            foreach (char c in dato)
            {
                if (!Char.IsLetter(c))
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
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.Apellido, this.Nombre);
            sb.AppendFormat("NACIONALIDAD: {0}\n", this.Nacionalidad);
            return sb.ToString();
        }
        #endregion
    }
}
