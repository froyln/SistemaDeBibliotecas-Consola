using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeBibliotecas
{
    public class Libros
    {
        public int id { get; }
        public string nombre { get; }
        public List<Autor> autores { get; }
        public Genero genero { get; }
        public Libros(int id, string nombre, Genero genero, List<Autor> autores)
        {
            this.id = id;
            this.nombre = nombre;
            this.autores = autores;
            this.genero = genero;
        }
    }
}
