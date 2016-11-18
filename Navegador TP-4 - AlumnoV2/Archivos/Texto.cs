using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {

        private string filePath;


        public Texto(string archivo)
        {
            this.filePath = archivo;
        }

        public bool guardar(string datos)
        {
            bool value = false;
            using (StreamWriter file = new StreamWriter(this.filePath, true))
            {
                file.WriteLine(datos);
                value = true;
            }
            return value;
        }

        public bool leer(out List<string> datos)
        {
            bool value = false;
            datos = new List<string>();

            using (StreamReader file = new StreamReader(this.filePath))
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
