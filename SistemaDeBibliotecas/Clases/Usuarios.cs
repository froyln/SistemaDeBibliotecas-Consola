using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeBibliotecas
{
    public class Usuarios
    {
        public int id { get; }
        public string nombre { get; }
        public string correo { get; }
        public string telefono { get; }
        public Usuarios(int id, string nombre, string correo, string telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.correo = correo;
            this.telefono = telefono;
        }
    }
}
