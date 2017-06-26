using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string filePath;
        public Texto(string archivo)
        {
            this.filePath = archivo;
        }

        public bool Guardar(string datos)
        {
            bool value = false;
            using(System.IO.StreamWriter file = new System.IO.StreamWriter(this.filePath, true))
            {
                file.WriteLine(datos);
                value = true;
            }
            return value;
        }

        public bool Leer(out List<string> datos)
        {
            bool value = false;
            datos = new List<string>();
            using(System.IO.StreamReader file = new System.IO.StreamReader(this.filePath))
            {
                while (!file.EndOfStream)
                {
                    datos.Add(file.ReadLine());
                }
                value = true;
            }
            return value;
        }
    }
}
