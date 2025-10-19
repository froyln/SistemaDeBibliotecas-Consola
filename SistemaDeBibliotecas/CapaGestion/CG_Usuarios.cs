using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeBibliotecas
{
    public class CG_Usuarios
    {
        List<Usuarios> listaUsuarios = new List<Usuarios>();
        public void registrarUsuario(Usuarios usuario)
        {
            if (listaUsuarios.Any(l => l.id == usuario.id))
            {
                Menus.DisplayMensaje($"El ID '{usuario.id}' ya está en uso.", 11, 10);
                return;
            }
            listaUsuarios.Add(usuario);
            Menus.DisplayMensaje("Usuario registrado exitosamente.", 10, 10);
        }
        public void modificarUsuario(Usuarios usuarioAntiguo, Usuarios usuarioNuevo)
        {
            if (listaUsuarios.Any(l => l.id == usuarioNuevo.id && l != usuarioAntiguo))
            {
                Menus.DisplayMensaje($"El ID '{usuarioNuevo.id}' ya está en uso.", 11, 10);
                return;
            }
            int index = listaUsuarios.IndexOf(usuarioAntiguo);
            if (index != -1)
            {
                listaUsuarios[index] = usuarioNuevo;
            }
            Menus.DisplayMensaje("Usuario modificado exitosamente.", 10, 10);
        }
        public void eliminarUsuario(Usuarios usuario)
        {
            listaUsuarios.Remove(usuario);
            Menus.DisplayMensaje("Usuario eliminado exitosamente.", 10, 10);
        }
        public List<Usuarios> obtenerUsuarios()
        {
            return listaUsuarios;
        }
    }
}
