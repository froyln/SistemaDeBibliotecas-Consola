using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeBibliotecas.Clases;

namespace SistemaDeBibliotecas
{
    public class Usuarios : Base
    {
        public string correo { get; }
        public string telefono { get; }
        public Usuarios(int id, string nombre, string correo, string telefono) : base(id, nombre)
        {
            this.id = id;
            this.nombre = nombre;
            this.correo = correo;
            this.telefono = telefono;
        }
    }
}
