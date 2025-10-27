using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeBibliotecas.Clases;

namespace SistemaDeBibliotecas
{
    public class Prestamo : Base
    {
        public Usuarios usuario { get; }
        public Libros libro { get; }
        public DateTime fechaPrestamo { get; }
        public Prestamo(int id, Usuarios usuario, Libros libro, DateTime fechaPrestamo) : base(id, $"Prestamo_{id}")
        {
            this.id = id;
            this.usuario = usuario;
            this.libro = libro;
            this.fechaPrestamo = fechaPrestamo;
        }
    }
}
