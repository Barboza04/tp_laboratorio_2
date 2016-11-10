using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace EntidadesInstaciables
{
    public class Jornada
    {

        #region Atributos
        private List<Alumno> _alumnos;
        private Gimnasio.EClases _clase;
        private Instructor _instructor;
        #endregion

        #region Propiedades
        
        public List<Alumno> Alumnos { get { return this._alumnos;} }

        public Gimnasio.EClases Clase { get { return this._clase;} }

        public Instructor Instructor { get { return this._instructor;} }

        #endregion

        #region Constructores
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Gimnasio.EClases clase,Instructor instructor):this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guarda los datos de la jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada">Jornada a guardar</param>
        /// <returns>Retorna true si pudo guardar, sino lanza una excepcion</returns>
        public static bool Guardar(Jornada jornada)
        {
            try
            {
                Texto txt = new Texto();
                txt.Guardar("../../../Jornada.txt", jornada.ToString());
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Lee un archivo de texto y lo muestra por pantalla
        /// </summary>
        /// <returns>Retorna true si pudo leer, sino false</returns>
        public static bool Leer()
        {
            string datos;
            Texto txt = new Texto();
            if (!txt.Leer("Jornada.txt", out datos))
            {
                Console.WriteLine("Error al leer TXT");
                return false;
            }
            else
            {
                Console.WriteLine(datos);
                return true;
            }
        }

        /// <summary>
        /// Sobrecarga el metodo ToString
        /// </summary>
        /// <returns>Retorna una cadena con los datos de la jornada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            sb.AppendLine("CLASE DE " + this._clase.ToString() + " POR " + this._instructor.ToString());
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno a in this._alumnos)
            {
                sb.AppendLine(a.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Verifica si un alumno esta en la jornada
        /// </summary>
        /// <param name="j">Jornada donde se va a buscar el alumno</param>
        /// <param name="a">Alumno a buscar</param>
        /// <returns>Retorna true si encuentra al alumno, sino false</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach(Alumno al in j._alumnos)
            {
                if (al==a)
                    throw new AlumnoRepetidoException();
            }
            return false;
        }

        /// <summary>
        /// Verifica si un alumno esta en la jornada
        /// </summary>
        /// <param name="j">Jornada donde se va a buscar el alumno</param>
        /// <param name="a">Alumno a buscar</param>
        /// <returns>Retorna flase si encuentra al alumno, sino true</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un alumno a la jornada si éste no esta en la misma
        /// </summary>
        /// <param name="j">Jornada donde se agregara el alumno</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns>Retorna la jornada</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j._alumnos.Add(a);
            return j;
        }
        #endregion

    }
}
