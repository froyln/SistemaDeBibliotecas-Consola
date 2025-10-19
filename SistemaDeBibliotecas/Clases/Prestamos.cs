using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeBibliotecas
{
    public class Prestamo
    {
        public int id { get; }
        public Usuarios usuario { get; }
        public Libros libro { get; }
        public DateTime fechaPrestamo { get; }
        private DateTime? fechaDevolucion {get; set; }
        public Prestamo(int id, Usuarios usuario, Libros libro, DateTime fechaPrestamo)
        {
            this.id = id;
            this.usuario = usuario;
            this.libro = libro;
            this.fechaPrestamo = fechaPrestamo;
        }
    }
}
