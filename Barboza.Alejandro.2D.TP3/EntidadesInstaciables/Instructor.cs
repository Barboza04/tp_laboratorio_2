using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using EntidadesInstaciables;

namespace EntidadesInstaciables
{
    public sealed class Instructor:PersonaGimnasio
    {

        #region Atributos
        private Queue<Gimnasio.EClases> _clasesDelDia;
        private static Random _random;
        #endregion

        #region Propiedad
        public Random Random { get { return Instructor._random;} }
        #endregion

        #region Constructores
        public Instructor()
        {

        }

        static Instructor()
        {
            Instructor._random = new Random();
        }

        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id,nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            this._randomClases();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Carga aleatoriamente dos clases al instructor
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2;i++ )
                this._clasesDelDia.Enqueue(((Gimnasio.EClases)_random.Next(0, 4)));

        }

        /// <summary>
        /// Muestra las clases del instructor
        /// </summary>
        /// <returns>Retorna una cadena con las clases</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA:");
            foreach(Gimnasio.EClases c in this._clasesDelDia)
            {
                sb.AppendLine(c.ToString());
            }
                return sb.ToString();
        }
        
        /// <summary>
        /// Muestra los datos del instructor
        /// </summary>
        /// <returns>Retorna una cadena con los datos</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Sobreescribe el metodo ToString
        /// </summary>
        /// <returns>Retorna una cadena con los datos del instructor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Compara un instructor con una clase, segun si éste da la clase
        /// </summary>
        /// <param name="ins">Instructor a copmparar</param>
        /// <param name="clase">Clase que debe dar el instructor</param>
        /// <returns>Retorna true si la clase esta en la lista del instructor, sino false</returns>
        public static bool operator ==(Instructor ins, Gimnasio.EClases clase)
        {
            foreach (Gimnasio.EClases c in ins._clasesDelDia)
            {
                if (c == clase)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Compara un instructor con una clase, segun si éste da la clase
        /// </summary>
        /// <param name="ins">Instructor a copmparar</param>
        /// <param name="clase">Clase que no debe dar el instructor</param>
        /// <returns>Retorna true si la clase no esta en la lista del instructor, sino false</returns>
        public static bool operator !=(Instructor ins, Gimnasio.EClases clase)
        {
            return !(ins == clase);
        }
        #endregion

    }
}
