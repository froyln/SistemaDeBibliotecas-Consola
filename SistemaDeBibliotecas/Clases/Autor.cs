using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeBibliotecas.Clases;

namespace SistemaDeBibliotecas
{
    public class Autor : Base
    {
        public Autor(string nombre) : base(0, nombre)
        {
            this.nombre = nombre;
        }
    }
}
