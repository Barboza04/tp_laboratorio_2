using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public class Changuito
    {
        private List<Producto> _productos;
        private int _espacioDisponible;

        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }

        #region "Constructores"
        private Changuito()
        {
            this._productos = new List<Producto>();
        }

        public Changuito(int espacioDisponible)
            :this()
        {
            this._espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el changuito y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Mostrar(ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public string Mostrar(ETipo tipo) //quitar static
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", this._productos.Count, this._espacioDisponible);
            sb.AppendLine("");
            foreach (Producto p in this._productos)
            {
                switch (tipo)
                {
                    case ETipo.Snacks:
                        if(p is Snacks)
                        sb.AppendLine(p.Mostrar());
                        break;
                    case ETipo.Dulce:
                        if (p is Dulce)
                        sb.AppendLine(p.Mostrar());
                        break;
                    case ETipo.Leche:
                        if (p is Leche)
                        sb.AppendLine(p.Mostrar());
                        break;
                    default:
                        sb.AppendLine(p.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
            if (c._productos.Count >= c._espacioDisponible)
                return c;
            for (int i = 0; i < c._productos.Count; i++)
            {
                if (c._productos[i] == p)
                    return c;
            }

            c._productos.Add(p);
            return c;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Changuito operator -(Changuito c, Producto p)
        {
            for (int i = 0; i < c._productos.Count; i++)
            {
                if (c._productos[i] == p)
                {
                    c._productos.RemoveAt(i);
                    break;
                }
            }

            return c;
        }
        #endregion
    }
}
