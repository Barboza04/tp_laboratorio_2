using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
    public class Jornada
    {
        #region "Atributos"
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _profesor;
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Retorna o inicializa el valor del atributo alumnos
        /// </summary>
        public List<Alumno> Alumnos { get { return this._alumnos;}
            set { this._alumnos = value;} }
        /// <summary>
        /// Retorna o inicializa el valor del atributo clase
        /// </summary>
        public Universidad.EClases Clase { get { return this._clase;}
            set { this._clase = value;} }
        /// <summary>
        /// Retorna o inicializa el valor del atributo profesor
        /// </summary>
        public Profesor Instructor { get { return this._profesor;}
            set { this._profesor = value;} }
        #endregion

        #region "Constructores"
        /// <summary>
        /// Inicializa la instancia con valores por defecto en sus atributos
        /// </summary>
        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Inicializa la instancia con los valores recibidos por parametro
        /// </summary>
        /// <param name="clase">Enumerado que representa la clase de la Jornada</param>
        /// <param name="instructor">Profesor que imparte la clase</param>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            :this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Guarda los datos de la jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada">Jornada a guardar</param>
        /// <returns>Retorna true si pudo guardar, sino lanza un ArchivosException()</returns>
        public static bool Guardar(Jornada jornada)
        {
            try
            {
                Texto txt = new Texto();
                txt.Guardar("../../../Jornada.txt", jornada.ToString());
                return true;
            }
            catch (Exception)
            {
                throw new ArchivosException();
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
            sb.AppendLine("CLASE DE " + this._clase.ToString() + " POR " + this.Instructor.ToString());
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
            foreach (Alumno al in j._alumnos)
            {
                if (al == a)
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
