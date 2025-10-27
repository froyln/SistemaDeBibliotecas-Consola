using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeBibliotecas.Clases;

namespace SistemaDeBibliotecas
{
    public class Genero : Base
    {
        public Genero(string nombre) : base(0, nombre)
        {
            this.nombre = nombre;
        }
    }
}
