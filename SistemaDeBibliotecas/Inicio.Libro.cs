using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeBibliotecas
{
    public partial class Inicio
    {
        private void RegistrarNuevoLibro()
        {
            string[] preguntas = new string[]
            {
                "Ingrese el ID del libro:",
                "Ingrese el nombre del libro:",
                "Ingrese el género del libro:"
            };

            string[] respuestas = Menus.MenuPreguntasLibros(
                preguntas,
                9,
                8
                );

            List<Autor> autores = new List<Autor>();
            for (int i = 3; i < respuestas.Length; i++) 
            { 
                autores.Add(new Autor(respuestas[i]));
            }

            Genero genero = new Genero(respuestas[2]);

            try
            {
                Libros nuevoLibro = new Libros(
                Convert.ToInt32(respuestas[0]),
                respuestas[1],
                genero,
                autores
                );

                cgLibros.registrarLibro(nuevoLibro);
            } 
            catch
            {
                Menus.DisplayMensaje("Datos inválidos.", 11, 10);
                return;
            }
        }
        private void ModificarLibro()
        {
            string[] preguntaInicial = new string[]
            {
                "Ingrese el ID del libro a modificar:"
            };
            string[] respuestaInicial = Menus.MenuPreguntasPlantilla(
                preguntaInicial,
                9,
                8
                );

            int idLibroAModificar = 0;
            try 
            {
                idLibroAModificar = Convert.ToInt32(respuestaInicial[0]);
            }
            catch
            {
                Menus.DisplayMensaje("ID inválido.", 11, 10);
                return;
            }

            Libros libroAntiguo = cgLibros.obtenerLibros().Find(libro => libro.id == idLibroAModificar);
            if (libroAntiguo == null)
            {
                Menus.DisplayMensaje("Libro no encontrado.", 11, 10);
                return;
            }

            if (cgPrestamos.obtenerPrestamosActivos().Any(prestamo => prestamo.libro.id == libroAntiguo.id))
            {
                Menus.DisplayMensaje("No se puede modificar un libro que está prestado actualmente.", 11, 10);
                return;
            }

            string[] preguntas = new string[]
            {
                "Ingrese el nuevo ID del libro:",
                "Ingrese el nuevo nombre del libro:",
                "Ingrese el nuevo género del libro:"
            };
            for (int i = 0; i < libroAntiguo.autores.Count; i++)
            {
                preguntas = preguntas.Append($"Ingrese el nuevo autor {i + 1}:").ToArray();
            }

            string[] valoresLibroNuevo = Menus.MenuPreguntasPlantilla(
                preguntas,
                9,
                8
                );

            List<Autor> nuevosAutores = new List<Autor>();
            for (int i = 3; i < valoresLibroNuevo.Length; i++)
            {
                nuevosAutores.Add(new Autor(valoresLibroNuevo[i]));
            }

            Genero nuevoGenero = new Genero(valoresLibroNuevo[2]);
            Libros libroNuevo = new Libros(
                Convert.ToInt32(valoresLibroNuevo[0]),
                valoresLibroNuevo[1],
                nuevoGenero,
                nuevosAutores
                );

            cgLibros.modificarLibro(libroAntiguo, libroNuevo);
        }
        private void EliminarLibro()
        {
            string[] pregunta = {
                "Ingrese el ID del libro a eliminar:"
            };

            string[] respuesta = Menus.MenuPreguntasPlantilla(
                pregunta,
                9,
                8
                );

            if (cgPrestamos.obtenerPrestamosActivos().Any(prestamo => prestamo.libro.id.ToString() == respuesta[0]))
            {
                Menus.DisplayMensaje("No se puede eliminar un libro que está prestado actualmente.", 11, 10);
                return;
            }

            try 
            { 
                int idLibroAEliminar = Convert.ToInt32(respuesta[0]);
                Libros libroAEliminar = cgLibros.obtenerLibros().Find(libro => libro.id == idLibroAEliminar);
                cgLibros.eliminarLibro(libroAEliminar);
            }
            catch
            {
                Menus.DisplayMensaje("ID inválido.", 11, 10);
                return;
            }
        }
        private void ConsultarLibrosDisponibles()
        {
            Menus.DisplayLibros(cgLibros.obtenerLibrosDisponibles(cgPrestamos.obtenerPrestamosActivos()));
        }
    }
}
