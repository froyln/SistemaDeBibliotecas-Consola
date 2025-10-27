using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeBibliotecas.Clases
{
    public class Base
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public Base(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
    }
}
