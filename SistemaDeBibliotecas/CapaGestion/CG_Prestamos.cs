using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeBibliotecas
{
    public class CG_Prestamos
    {
        private List<Prestamo> listaPrestamosActivos = new List<Prestamo>();
        private List<Prestamo> listaPrestamos = new List<Prestamo>();
        public void registrarPrestamo(Prestamo prestamo)
        {
            listaPrestamos.Add(prestamo);
            listaPrestamosActivos.Add(prestamo);
            Menus.DisplayMensaje("Prestamo registrado exitosamente.", 10, 10);
        }
        public void registrarDevolucion(Prestamo prestamo)
        {
            var index = listaPrestamosActivos.IndexOf(prestamo);
            if (index != -1)
            {
                listaPrestamosActivos.RemoveAt(index);
            }
            Menus.DisplayMensaje("Devolucion realizada exitosamente.", 10, 10);
        }
        public List<Prestamo> obtenerPrestamosActivos()
        {
            return listaPrestamosActivos;
        }
        public List<Prestamo> obtenerPrestamosPorUsuario(Usuarios usuario, bool soloActivo)
        {
            if (usuario == null)
                return new List<Prestamo>();

            if (!soloActivo)
                return listaPrestamos.Where(p => p.usuario.id == usuario.id).ToList();

            return listaPrestamosActivos.Where(p => p.usuario.id == usuario.id).ToList();
        }
        public List<Prestamo> obtenerPrestamos()
        {
            return listaPrestamos;
        }
    }
}
