using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class PersonaGimnasio:Persona
    {

        #region Atributo
        private int _identificador;
        #endregion

        #region Propiedad
        public int Identificador { get { return this._identificador;} }
        #endregion

        #region Constructores
        public PersonaGimnasio()
        {

        }

        public PersonaGimnasio(int id, string nombre,string apellido,string dni, ENacionalidad nacionalidad)
            :base(nombre,apellido,dni,nacionalidad)
        {
            this._identificador = id;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Carga un Stringbuilder con los datos de la instancia
        /// </summary>
        /// <returns>Retorna el Stringbuilder</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("CARNET NÚMERO: " + this._identificador.ToString());
            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Compara la instacia actual con la recibida por su tipo
        /// </summary>
        /// <param name="obj">Instancia a comparar</param>
        /// <returns>Retorna true si son del mismo tipo, sino false</returns>
        public override bool Equals(object obj)
        {
            return this.GetType() == obj.GetType();
        }

        /// <summary>
        /// Compara dos instancias por su tipo y su identificador o dni
        /// </summary>
        /// <param name="pg1">Primer instancia a comparar</param>
        /// <param name="pg2">Segunda instancia a comparar</param>
        /// <returns>Retorna true si son iguales, sino false</returns>
        public static bool operator ==(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            bool value = false;
            if ((pg1.Equals(pg2)) && (pg1._identificador == pg2._identificador) || (pg1.DNI == pg2.DNI))
            {
                value = true;
            }
            return value;
        }

        /// <summary>
        /// Compara dos instancias por su tipo y su identificador o dni
        /// </summary>
        /// <param name="pg1">Primer instancia a comparar</param>
        /// <param name="pg2">Segunda instancia a comparar</param>
        /// <returns>Retorna true si son distintas, sino false</returns>
        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion

    }
}
