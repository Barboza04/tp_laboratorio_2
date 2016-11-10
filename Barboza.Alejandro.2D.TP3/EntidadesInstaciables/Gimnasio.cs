using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using EntidadesAbstractas;
using Excepciones;
using Archivos;

namespace EntidadesInstaciables
{
    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Instructor))]
    [XmlInclude(typeof(Jornada))]
    public class Gimnasio
    {

        #region Atributos
        private List<Alumno> _alumnos;
        private List<Instructor> _instructores;
        private List<Jornada> _jornada;
        #endregion

        #region Indexador
        /// <summary>
        /// Devuelve una jornada especifica de la lista
        /// </summary>
        /// <param name="index">indice de la lista</param>
        /// <returns>jornada en el indice recibido por parametro</returns>
        public Jornada this[int i] { get { return this._jornada[i]; } }
        #endregion

        #region Propiedades

        public List<Alumno> Alumnos { get { return this._alumnos;} }

        public List<Instructor> Instructores { get { return this._instructores;} }

        public List<Jornada> Jornada { get { return this._jornada;} }

        #endregion

        #region Enumerado
        public enum EClases
        {
            CrossFit,
            Natacion,
            Pilates,
            Yoga
        }
        #endregion

        #region Constructor
        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornada = new List<Jornada>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Genera un archivo xml con los datos de la instancia
        /// </summary>
        /// <param name="gim">Instancia a guardar en xml</param>
        /// <returns>Retorna true si pudo generar el archivo, sino lanza una excepcion</returns>
        public static bool Guardar(Gimnasio gim)
        {
            try
            {
                Xml<Gimnasio> xml = new Xml<Gimnasio>();
                xml.Guardar("../../../Gimnasio.xml", gim);
                return true;
                    
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Lee un archivo xml y lo guarda en la instacia recibida
        /// </summary>
        /// <param name="gim">Instancia donde se guradran los datos leidos</param>
        /// <returns>Retorna true e imprime los datos en pantalla si tuvo exito, sino false</returns>
        public static bool Leer(Gimnasio gim)
        {
            bool value = false;
            Xml<Gimnasio> xml = new Xml<Gimnasio>();
            if (!xml.Leer("Gimasio.xml", out gim))
                Console.WriteLine("Error al leer XML");
            else
                value = true;
                Console.WriteLine(gim.ToString());
            return value;
        }

        /// <summary>
        /// Carga un Stringbuilder con los datos de la instancia recibida
        /// </summary>
        /// <param name="gim">Instancia a mostrar</param>
        /// <returns>Retorna el Stringbuilder</returns>
        private static string MostrarDatos(Gimnasio gim)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada j in gim.Jornada)
            {
                sb.Append(j.ToString());
                sb.AppendLine("<------------------------------------------>");
                sb.AppendLine();
            }
            return sb.ToString();
        }

        /// <summary>
        /// Sobreescribe el metodo ToString
        /// </summary>
        /// <returns>Retorna una cadena con los datos de la instancia</returns>
        public override string ToString()
        {
            return Gimnasio.MostrarDatos(this);
        }

        /// <summary>
        /// Compara un gimnasio con un alumno, segun si el alumno asisite al mismo
        /// </summary>
        /// <param name="g">Gimnasio donde se busca el alumno</param>
        /// <param name="a">Alumno a buscar en al gimnasio</param>
        /// <returns>Retorna flase si el alumno no esta en la lista, sino lanza una excepcion</returns>
        public static bool operator ==(Gimnasio g, Alumno a)
        {
            bool value = false;
            foreach (Alumno al in g._alumnos)
            {
                if (al == a)
                {
                    throw new AlumnoRepetidoException();
                }
            }
            return value;
        }

        /// <summary>
        /// Compara un gimnasio con un alumno, segun si el alumno asisite al mismo
        /// </summary>
        /// <param name="g">Gimnasio donde se busca el alumno</param>
        /// <param name="a">Alumno a buscar en al gimnasio</param>
        /// <returns>Retorna true si el alumno no esta en la lista, sino lanza una excepcion</returns>
        public static bool operator !=(Gimnasio g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Compara un gimnasio con un instructor, segun si el instructor da clases en el mismo
        /// </summary>
        /// <param name="g">Gimnasio donde se busca al instructor</param>
        /// <param name="i">Instructor a buscar en al gimnasio</param>
        /// <returns>Retorna true si el instructor esta en la lista, sino false</returns>
        public static bool operator ==(Gimnasio g, Instructor i)
        {
            foreach (Instructor ins in g._instructores)
            {
                if (ins == i)
                return true;
            }
            return false;
        }

        /// <summary>
        /// Compara un gimnasio con un instructor, segun si el instructor da clases en el mismo
        /// </summary>
        /// <param name="g">Gimnasio donde se busca al instructor</param>
        /// <param name="i">Instructor a buscar en al gimnasio</param>
        /// <returns>Retorna true si el instructor no esta en la lista, sino false</returns>
        public static bool operator !=(Gimnasio g, Instructor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Compara un gimnasio con una clases para buscar el primer instructor que puede dar la clase
        /// </summary>
        /// <param name="g">Gimnasio donde se busca al instructor</param>
        /// <param name="c">Clase que debe dar el instructor</param>
        /// <returns>Retorna el primer instructor que puede dar la clase, si no hay lanza una excepcion</returns>
        public static Instructor operator ==(Gimnasio g, Gimnasio.EClases c)
        {
            foreach (Instructor i in g._instructores)
            {
                if(i==c)
                    return i;
            }
            throw new SinInstructorException();
        }

        /// <summary>
        /// Compara un gimnasio con una clases para buscar el primer instructor que no puede dar la clase
        /// </summary>
        /// <param name="g">Gimnasio donde se busca al instructor</param>
        /// <param name="c">Clase que no debe dar el instructor</param>
        /// <returns>Retorna el primer instructor que no puede dar la clase</returns>
        public static Instructor operator !=(Gimnasio g, Gimnasio.EClases c)
        {
            foreach (Instructor i in g._instructores)
            {
                if (i != c)
                    return i;
            }
            throw new SinInstructorException();
        }

        /// <summary>
        /// Agrega un alumno al gimnasio, si éste no esta en el mismo
        /// </summary>
        /// <param name="g">Gimnasio donde se agregara al alumno</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns>Retorna el gimnasio</returns>
        public static Gimnasio operator +(Gimnasio g, Alumno a)
        {
            if (g != a)
                g._alumnos.Add(a);
            return g;
        }

        /// <summary>
        /// Agrega un instructor al gimnasio, si éste no esta en el mismo
        /// </summary>
        /// <param name="g">Gimnasio donde se agregara al instructor</param>
        /// <param name="i">Instructor a agregar</param>
        /// <returns>Retorna el gimnasio</returns>
        public static Gimnasio operator +(Gimnasio g, Instructor i)
        {
            if (g != i)
                g._instructores.Add(i);
            return g;
        }

        /// <summary>
        /// Agrega una jornada al gimnasio con su instructor y alumnos
        /// </summary>
        /// <param name="g">Gimnasio donde se agregara la jornada</param>
        /// <param name="c">Clase que se dara en la jornada</param>
        /// <returns>Retorna el gimnasio</returns>
        public static Gimnasio operator +(Gimnasio g, Gimnasio.EClases c)
        {
            Jornada j = new Jornada(c,g==c);
            foreach(Alumno a in g._alumnos)
            {
                if (a == c)
                    j += a;
            }
            g._jornada.Add(j);
            return g;
        }
        #endregion

    }
}
