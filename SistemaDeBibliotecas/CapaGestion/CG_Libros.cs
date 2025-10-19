using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeBibliotecas
{
    public class CG_Libros
    {
        List<Libros> listaLibros = new List<Libros>();
        public void registrarLibro(Libros libro)
        {
            if (listaLibros.Any(l => l.id == libro.id))
            {
                Menus.DisplayMensaje($"El ID '{libro.id}' ya está en uso.", 11, 10);
                return;
            }
            listaLibros.Add(libro);
            Menus.DisplayMensaje("Libro registrado exitosamente.", 10, 10);
        }
        public void modificarLibro(Libros libroAntiguo, Libros libroNuevo)
        {
            if (libroAntiguo.id != libroNuevo.id && listaLibros.Any(l => l.id == libroNuevo.id))
            {
                Menus.DisplayMensaje($"El ID '{libroNuevo.id}' ya está en uso.", 11, 10);
                return;
            }

            int index = listaLibros.IndexOf(libroAntiguo);
            if (index != -1)
                listaLibros[index] = libroNuevo;

            Menus.DisplayMensaje("Libro modificado exitosamente.", 10, 10);
        }
        public void eliminarLibro(Libros libro)
        {
            if (libro == null)
            {
                Menus.DisplayMensaje("Libro no encontrado.", 11, 10);
                return;
            }
            listaLibros.Remove(libro);
            Menus.DisplayMensaje("Libro eliminado exitosamente.", 10, 10);
        }
        public List<Libros> obtenerLibros()
        {
            return listaLibros;
        }
        public List<Libros> obtenerLibrosDisponibles(List<Prestamo> prestamos)
        {
            if (prestamos == null || prestamos.Count == 0)
            {
                return listaLibros;
            }
            List<Libros> librosPrestados = prestamos.Select(p => p.libro).ToList();
            return listaLibros.Except(librosPrestados).ToList();
        }
    }
}
