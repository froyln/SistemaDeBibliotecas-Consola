using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeBibliotecas.Clases;

namespace SistemaDeBibliotecas
{
    public class Libros : Base
    {
        public List<Autor> autores { get; }
        public Genero genero { get; }
        public Libros(int id, string nombre, Genero genero, List<Autor> autores) : base(id, nombre)
        {
            this.id = id;
            this.nombre = nombre;
            this.autores = autores;
            this.genero = genero;
        }
    }
}
