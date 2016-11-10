using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Atributos
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;
        #endregion

        #region Enumerado
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion

        #region Propiedades
        public string Apellido { get { return this._apellido; } set { this._apellido=this.ValidarNombreApellido(value);} }
        
        public int DNI { get { return this._dni; } set { this._dni = this.ValidarDni(this.Nacionalidad, value);} }

        public ENacionalidad Nacionalidad { get { return this._nacionalidad; } set { this._nacionalidad=value;} }
        
        public string Nombre { get { return this._nombre; } set { this._nombre=this.ValidarNombreApellido(value);} }
        
        public string StringToDni { set { this._dni = this.ValidarDni(this.Nacionalidad,value);} }
        #endregion

        #region Constructores
        public Persona()
        {

        }

        public Persona(string nombre,string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;

        }

        public Persona(string nombre,string apellido,int dni,ENacionalidad nacionalidad)
            :this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre,string apellido,string dni,ENacionalidad nacionalidad)
            :this(nombre,apellido,nacionalidad)
        {
            this.StringToDni = dni;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Valida que el dni este dentro del rango correspondiente segun la nacionalidad a partir de un entero
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">Entero a validar</param>
        /// <returns>Retorna el dato si es valido, sino lanza una excepcion</returns>
        private int ValidarDni(ENacionalidad nacionalidad,int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                        throw new NacionalidadInvalidaException(dato.ToString());
                    break;
                case ENacionalidad.Extranjero:
                    if (dato < 89999999 || dato > 99999999)
                        throw new NacionalidadInvalidaException();
                    break;
            }
            return dato;
        }

        /// <summary>
        /// Valida que el dni contenga solo numeros a partir de una cadena
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">Cadena a validar</param>
        /// <returns>Si la cadena es valida, llama a la funcion que valida su rango, sino lanza una excepcion</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            if (dato != null)
            {
                if (!int.TryParse(dato, out dni))
                    throw new DniInvalidoException(dato.ToString());
                return this.ValidarDni(nacionalidad, dni);
            }
            throw new DniInvalidoException();
        }

        /// <summary>
        /// Valida que el una cadena contenga solo letras
        /// </summary>
        /// <param name="dato">Cadena a validar</param>
        /// <returns>Retorna la cadena si es valida, sino retorna una cadena vacia</returns>
        private string ValidarNombreApellido(string dato)
        {
            if (dato != null)
            {
                foreach (char c in dato)
                {
                    if (!char.IsLetter(c))
                        break;
                    else
                        return dato;
                }
            }
            return "";
        }

        /// <summary>
        /// Carga un Stringbuilder con los datos de la instancia
        /// </summary>
        /// <returns>Retorna el Stringbuilder</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NOMBRE COMPLETO : " + this.Apellido + ", " + this.Nombre);
            sb.AppendLine("NACIONALIDAD: " + this.Nacionalidad);
            return sb.ToString();
        }
        #endregion
    }
}
