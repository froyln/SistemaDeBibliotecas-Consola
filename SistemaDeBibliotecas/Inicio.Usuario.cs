using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeBibliotecas
{
    public partial class Inicio
    {
        public void RegistrarNuevoUsuario()
        {
            string[] preguntas = new string[]
            {
                "Ingrese el ID del usuario:",
                "Ingrese el nombre del usuario:",
                "Ingrese el correo del usuario:",
                "Ingrese el teléfono del usuario:"
            };

            string[] respuestas = Menus.MenuPreguntasPlantilla(
                preguntas,
                9,
                8
                );
            
            try
            {
                Usuarios nuevoUsuario = new Usuarios(
                Convert.ToInt32(respuestas[0]),
                respuestas[1],
                respuestas[2],
                respuestas[3]
                );

                cgUsuarios.registrarUsuario(nuevoUsuario);
            }
            catch
            {
                Menus.DisplayMensaje("Datos inválidos.", 11, 10);
                return;
            }
            
        }
        public void ModificarUsuario()
        {
            string[] pregunta = new string[]
            {
                "Ingrese el ID del usuario a modificar:"
            };

            string[] respuesta = Menus.MenuPreguntasPlantilla(
                pregunta,
                9,
                8
                );

            int idUsuarioAModificar = 0;
            try
            {
                idUsuarioAModificar = Convert.ToInt32(respuesta[0]);
            }
            catch
            {
                Menus.DisplayMensaje("ID inválido.", 11, 10);
                return;
            }
            Usuarios usuarioAntiguo = cgUsuarios.obtenerUsuarios().Find(usuario => usuario.id == idUsuarioAModificar);
            if (usuarioAntiguo == null)
            {
                Menus.DisplayMensaje("Usuario no encontrado.", 11, 10);
                return;
            }

            if (cgPrestamos.obtenerPrestamosActivos().Any(prestamo => prestamo.usuario.id == usuarioAntiguo.id))
            {
                Menus.DisplayMensaje("No se puede modificar, el usuario tiene un prestamo activo.", 11, 10);
                return;
            }

            string[] preguntasNuevas = new string[]
            {
                "Ingrese el nuevo ID del usuario:",
                "Ingrese el nuevo nombre del usuario:",
                "Ingrese el nuevo correo del usuario:",
                "Ingrese el nuevo teléfono del usuario:"
            };

            string[] respuestasNuevas = Menus.MenuPreguntasPlantilla(
                preguntasNuevas,
                9,
                8
                );

            Usuarios usuarioNuevo = new Usuarios(Convert.ToInt32(respuestasNuevas[0]),
                respuestasNuevas[1],
                respuestasNuevas[2],
                respuestasNuevas[3]
                );
            cgUsuarios.modificarUsuario(usuarioAntiguo, usuarioNuevo);
        }
        public void EliminarUsuario()
        {
            string[] pregunta = new string[]
            {
                "Ingrese el ID del usuario a eliminar:"
            };

            string[] respuesta = Menus.MenuPreguntasPlantilla(
                pregunta,
                9,
                8
                );

            int idUsuarioAEliminar = 0;
            try
            {
                idUsuarioAEliminar = Convert.ToInt32(respuesta[0]);
            }
            catch
            {
                Menus.DisplayMensaje("ID inválido.", 11, 10);
                return;
            }

            if (cgPrestamos.obtenerPrestamosActivos().Any(prestamo => prestamo.usuario.id == idUsuarioAEliminar))
            {
                Menus.DisplayMensaje("No se puede eliminar, el usuario tiene un prestamo activo.", 11, 10);
                return;
            }

            Usuarios usuarioAEliminar = cgUsuarios.obtenerUsuarios().Find(usuario => usuario.id == idUsuarioAEliminar);
            if (usuarioAEliminar == null)
            {
                Menus.DisplayMensaje("Usuario no encontrado.", 11, 10);
                return;
            }

            cgUsuarios.eliminarUsuario(usuarioAEliminar);
        }
        public void ConsultarUsuarios()
        {
            Menus.DisplayUsuarios(cgUsuarios.obtenerUsuarios());
        }
    }
}
