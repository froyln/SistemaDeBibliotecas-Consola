using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeBibliotecas
{
    public partial class Inicio
    {
        private void RegistrarNuevoPrestamo()
        {
            string[] preguntas = new string[]
            {
                "Ingrese el ID del préstamo:",
                "Ingrese el ID del usuario:",
                "Ingrese el ID del libro:"
            };

            string[] respuestas = Menus.MenuPreguntasPlantilla(
                preguntas,
                9,
                8
                );

            List<Usuarios> usuariosEncontrados = cgUsuarios.obtenerUsuarios().Where(usuario => usuario.id.ToString() == respuestas[1]).ToList();
            if (usuariosEncontrados == null || usuariosEncontrados.Count == 0)
            {
                Menus.DisplayMensaje("Usuario no encontrado.", 11, 10);
                return;
            }
            Usuarios usuarioPrestamo = usuariosEncontrados[0];

            List<Libros> librosEncontrados = cgLibros.obtenerLibros().Where(libro => libro.id.ToString() == respuestas[2]).ToList();
            if (librosEncontrados == null || librosEncontrados.Count == 0)
            {
                Menus.DisplayMensaje("Libro no encontrado.", 11, 10);
                return;
            }
            Libros libroPrestamo = librosEncontrados[0];

            try
            {
                Prestamo nuevoPrestamo = new Prestamo(
                Convert.ToInt32(respuestas[0]),
                usuarioPrestamo,
                libroPrestamo,
                DateTime.Now
                );

                cgPrestamos.registrarPrestamo(nuevoPrestamo);
            }
            catch
            {
                Menus.DisplayMensaje("Datos inválidos.", 11, 10);
                return;
            }
        }
        private void DevolverPrestamo()
        {
            string[] pregunta = new string[]
            {
                "Ingrese el ID del préstamo a devolver:"
            };

            string[] respuesta = Menus.MenuPreguntasPlantilla(
                pregunta,
                9,
                8
                );

            int idPrestamoADevolver = 0;
            try
            {
                idPrestamoADevolver = Convert.ToInt32(respuesta[0]);
            }
            catch
            {
                Menus.DisplayMensaje("ID inválido.", 11, 10);
                return;
            }
            Prestamo prestamoADevolver = cgPrestamos.obtenerPrestamos().Find(prestamo => prestamo.id == idPrestamoADevolver);
            if (prestamoADevolver == null)
            {
                Menus.DisplayMensaje("Préstamo no encontrado.", 11, 10);
                return;
            }
            cgPrestamos.registrarDevolucion(prestamoADevolver);
        }
        private void ObtenerPrestamosActivos()
        {
            Menus.DisplayPrestamos(cgPrestamos.obtenerPrestamosActivos());
        }
        private void ConsultarPrestamosPorUsuario()
        {
            string[] preguntaActivo = new string[]
            {
                "Prestamos Activos",
                "Todos los prestamos",
                "Volver al menus principal"
            };

            int respuestaActivo = Menus.MenuSeleccionPlantilla(
                "¿Desea ver solo los préstamos activos?",
                preguntaActivo,
                9,
                9
                );

            bool soloActivos = false;
            switch (respuestaActivo)
            {
                case 0:
                    soloActivos = true;
                    break;
                case 1:
                    soloActivos = false;
                    break;
                case 2:
                    return;
            }

            string[] pregunta = new string[]
            {
                "Ingrese el ID del usuario:",
            };

            string[] respuesta = Menus.MenuPreguntasPlantilla(
                pregunta,
                12,
                14
                );

            int idUsuario = 0;
            try
            {
                idUsuario = Convert.ToInt32(respuesta[0]);
            }
            catch
            {
                Menus.DisplayMensaje("ID inválido.", 15, 16);
                return;
            }
            Usuarios usuario = cgUsuarios.obtenerUsuarios().Find(u => u.id == idUsuario);
            if (usuario == null)
            {
                Menus.DisplayMensaje("Usuario no encontrado.", 15, 16);
                return;
            }

            Menus.DisplayPrestamos(cgPrestamos.obtenerPrestamosPorUsuario(usuario, soloActivos));
        }
        private void ObtenerTodosLosPrestamos()
        {
            Menus.DisplayPrestamos(cgPrestamos.obtenerPrestamos());
        }
    }
}
