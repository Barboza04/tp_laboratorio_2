using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using EntidadesAbstractas;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Profesor))]
    [XmlInclude(typeof(Jornada))]
    public class Universidad
    {
        #region "Atributos"
        private List<Alumno> _alumnos;
        private List<Profesor> _profesores;
        private List<Jornada> _jornada;
        #endregion

        #region "Indexador"
        /// <summary>
        /// Devuelve una jornada especifica de la lista
        /// </summary>
        /// <param name="index">indice de la lista</param>
        /// <returns>jornada en el indice recibido por parametro</returns>
        public Jornada this[int i] { get { return this._jornada[i]; } }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Retorna el valor contenido en la lista de alumnos
        /// </summary>
        public List<Alumno> Alumnos { get { return this._alumnos; } }
        /// <summary>
        /// Retorna el valor contenido en la lista de profesores
        /// </summary>
        public List<Profesor> Instructores { get { return this._profesores; } }
        /// <summary>
        /// Retorna el valor contenido en la lista de jornadas
        /// </summary>
        public List<Jornada> Jornada { get { return this._jornada; } }
        #endregion

        public enum EClases { Laboratorio, Legislacion, Programacion, SPD}

        #region "Constructor"
        /// <summary>
        /// Inicializa la instancia con valores por defecto en sus atributos
        /// </summary>
        public Universidad()
        {
            this._alumnos = new List<Alumno>();
            this._profesores = new List<Profesor>();
            this._jornada = new List<Jornada>();
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Genera un archivo xml con los datos de la instancia
        /// </summary>
        /// <param name="uni">Instancia a guardar en xml</param>
        /// <returns>Retorna true si pudo generar el archivo, sino lanza un ArchivosException()</returns>
        public static bool Guardar(Universidad uni)
        {
            try
            {
                Xml<Universidad> xml = new Xml<Universidad>();
                xml.Guardar("../../../Gimnasio.xml", uni);
                return true;
                    
            }
            catch (Exception)
            {
                throw new ArchivosException();
            }
        }

        /// <summary>
        /// Lee un archivo xml y lo guarda en la instacia recibida
        /// </summary>
        /// <param name="uni">Instancia donde se guradran los datos leidos</param>
        /// <returns>Retorna true e imprime los datos en pantalla si tuvo exito, sino false</returns>
        public static bool Leer(Universidad uni)
        {
            bool value = false;
            Xml<Universidad> xml = new Xml<Universidad>();
            if (!xml.Leer("Gimasio.xml", out uni))
                Console.WriteLine("Error al leer XML");
            else
                value = true;
                Console.WriteLine(uni.ToString());
            return value;
        }

        /// <summary>
        /// Carga un Stringbuilder con los datos de la instancia recibida
        /// </summary>
        /// <param name="uni">Instancia a mostrar</param>
        /// <returns>Cadena con los datos del StringBuilder</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada j in uni.Jornada)
            {
                sb.Append(j.ToString());
                sb.AppendLine("<------------------------------------------>");
                sb.AppendLine();
            }
            return sb.ToString();
        }

        /// <summary>
        /// Expone los datos de la lista de jornadas
        /// </summary>
        /// <returns>Retorna una cadena con los datos de la lista de jornadas</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        /// <summary>
        /// Determina si un Alumno asiste a una Universidad
        /// </summary>
        /// <param name="u">Universidad donde se busca el Alumno</param>
        /// <param name="a">Alumno a buscar en la Universidad</param>
        /// <returns>Si el alumno asiste a la universidad lanza un
        /// AlumnoRepetidoException(), caso contrario retorna false</returns>
        public static bool operator ==(Universidad u, Alumno a)
        {
            foreach (Alumno al in u._alumnos)
            {
                if (al == a)
                {
                    throw new AlumnoRepetidoException();
                }
            }
            return false;
        }

        /// <summary>
        /// Determina si un Alumno no asiste a una Universidad
        /// </summary>
        /// <param name="u">Universidad donde se busca al Alumno</param>
        /// <param name="a">Alumno a buscar en la Universidad</param>
        /// <returns>Si el alumno asiste a la universidad lanza un
        /// AlumnoRepetidoException(), caso contrario retorna true</returns>
        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }

        /// <summary>
        /// Determina si un Profesor da clases en una Universidad
        /// </summary>
        /// <param name="u">Universidad donde se busca al Profesor</param>
        /// <param name="p">Profesor a buscar en la Universidad</param>
        /// <returns>true si el Profesor da clases en la Universidad</returns>
        public static bool operator ==(Universidad u, Profesor p)
        {
            foreach (Profesor prof in u._profesores)
            {
                if (prof == p)
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determina si un Profesor no da clases en una Universidad
        /// </summary>
        /// <param name="u">Universidad donde se busca al Profesor</param>
        /// <param name="p">Profesor a buscar en la Universidad</param>
        /// <returns>true si el Profesor no clases en la Universidad</returns>
        public static bool operator !=(Universidad u, Profesor p)
        {
            return !(u == p);
        }

        /// <summary>
        /// Compara una Universidad con una clase para buscar el primer Profesor
        /// que puede impartirla
        /// </summary>
        /// <param name="u">Universidad donde se busca al Profesor</param>
        /// <param name="c">Clase que debe dar el Profesor</param>
        /// <returns>Retorna el primer Profesor que puede dar la clase, si no
        /// hay lanza un SinProfesorException()</returns>
        public static Profesor operator ==(Universidad u, Universidad.EClases c)
        {
            foreach (Profesor p in u._profesores)
            {
                if(p == c)
                    return p;
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Compara una Universidad con una clase para buscar el primer Profesor
        /// que no puede impartirla
        /// </summary>
        /// <param name="u">Universidad donde se busca al Profesor</param>
        /// <param name="c">Clase que no debe dar el Profesor</param>
        /// <returns>Retorna el primer Profesor que no puede dar la clase</returns>
        public static Profesor operator !=(Universidad u, Universidad.EClases c)
        {
            foreach (Profesor p in u._profesores)
            {
                if (p != c)
                    return p;
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Agrega un alumno a la Universidad, si éste no esta en la misma
        /// </summary>
        /// <param name="u">Universidad donde se agregara al Alumno</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns>Retorna la Universidad</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
                u._alumnos.Add(a);
            return u;
        }

        /// <summary>
        /// Agrega un Profesor a la Universidad, si éste no esta en la misma
        /// </summary>
        /// <param name="u">Universidad donde se agregara al Profesor</param>
        /// <param name="p">Profesor a agregar</param>
        /// <returns>Retorna la Universidad</returns>
        public static Universidad operator +(Universidad u, Profesor p)
        {
            if (u != p)
                u._profesores.Add(p);
            return u;
        }

        /// <summary>
        /// Agrega una Jornada a la Universidad con su Profesor y alumnos
        /// </summary>
        /// <param name="u">Universidad donde se agregara la Jornada</param>
        /// <param name="c">Clase que se dara en la Jornada</param>
        /// <returns>Retorna la Universidad</returns>
        public static Universidad operator +(Universidad u, Universidad.EClases c)
        {
            Jornada j = new Jornada(c, u == c);
            foreach(Alumno a in u._alumnos)
            {
                if (a == c)
                    j += a;
            }
            u._jornada.Add(j);
            return u;
        }
        #endregion
    }
}
