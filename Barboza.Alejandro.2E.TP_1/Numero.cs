using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_01
{
    class Numero
    {
        private double _numero;

        /// <summary>
        /// Retorna el valor del atributo _numero
        /// </summary>
        /// <returns></returns>
        public double GetNumero()
        {
            return this._numero;
        }

        /// <summary>
        /// Inicializa el atributo _numero en 0
        /// </summary>
        public Numero():this(0)
        {
            
        }

        /// <summary>
        /// Inicializa el atributo _numero con el valor del parametro recibido
        /// </summary>
        /// <param name="numero">Valor para inicializar el atributo _numero</param>
        public Numero(double numero)
        {
            this._numero = numero;
        }

        /// <summary>
        /// Inicializa el atributo _numero con el valor del parametro recibido
        /// </summary>
        /// <param name="numero">String para inicializar el atributo _numero</param>
        public Numero(string numero)
        {
            this.SetNumero(numero);
        }

        /// <summary>
        /// Recibe un string y lo asigna al atributo _numero de la instancia
        /// </summary>
        /// <param name="numero">String a ser asignado en _numero</param>
        private void SetNumero(string numero)
        {
            this._numero = ValidarNumero(numero);
        }

        /// <summary>
        /// Recibe un string y lo parsea a double
        /// </summary>
        /// <param name="numeroString">String a parsear</param>
        /// <returns> Devuelve el valor del string recibido en forma de double, si no lo puede parsear devuelve 0</returns>
        private double ValidarNumero(string numeroString)
        {
            double value = 0;

            double.TryParse(numeroString, out value);
           
            return value;
        }
    }
}
