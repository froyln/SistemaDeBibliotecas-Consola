using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeBibliotecas
{
    public partial class Inicio
    {
        private readonly CG_Libros cgLibros = new CG_Libros();
        private readonly CG_Usuarios cgUsuarios = new CG_Usuarios();
        private readonly CG_Prestamos cgPrestamos = new CG_Prestamos();
        public void Iniciar()
        {
            while (true)
            {
                int opcion = Menus.MenuPrincipal("Sistema de Bibliotecas",
                    new string[]
                    {
                        "Gestion de Libros",
                        "Gestion de Usuarios",
                        "Gestion de Prestamos",
                        "Salir" }, 3, 2);
                switch (opcion)
                {
                    case 0:
                        GestionLibros();
                        break;
                    case 1:
                        GestionUsuarios();
                        break;
                    case 2:
                        GestionPrestamos();
                        break;
                    case 3:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                }
            }
        }
        public void GestionLibros()
        {
            int opcion = Menus.MenuSeleccionPlantilla("Gestion de libros",
                    new string[]
                    {
                        "Registrar nuevo Libro",
                        "Modificar un Libro",
                        "Eliminar un libro",
                        "Consultar libros disponibles",
                        "Volver al menu principal" }, 6, 5);
            switch (opcion)
            {
                case 0:
                    RegistrarNuevoLibro();
                    break;
                case 1:
                    ModificarLibro();
                    break;
                case 2:
                    EliminarLibro();
                    break;
                case 3:
                    ConsultarLibrosDisponibles();
                    break;
                case 4:
                    return;
            }
        }
        public void GestionUsuarios()
        {
            int opcion = Menus.MenuSeleccionPlantilla("Gestion de usuarios",
                    new string[]
                    {
                        "Registrar nuevo Usuario",
                        "Modificar un Usuario",
                        "Eliminar un Usuario",
                        "Consultar usuarios",
                        "Volver al menu principal" }, 6, 5);
            switch (opcion)
            {
                case 0:
                    RegistrarNuevoUsuario();
                    break;
                case 1:
                    ModificarUsuario();
                    break;
                case 2:
                    EliminarUsuario();
                    break;
                case 3:
                    ConsultarUsuarios();
                    break;
                case 4:
                    return;
            }
        }
        public void GestionPrestamos()
        {
            int opcion = Menus.MenuSeleccionPlantilla("Gestion de Prestamos",
                    new string[]
                    {
                        "Realizar un préstamo",
                        "Registrar devolución de un libro",
                        "Consultar prestamos activos",
                        "Consultar prestamos por usuario",
                        "Consultar todos los prestamos",
                        "Volver al menu principal" }, 6, 5);
            switch (opcion)
            {
                case 0:
                    RegistrarNuevoPrestamo();
                    break;
                case 1:
                    DevolverPrestamo();
                    break;
                case 2:
                    ObtenerPrestamosActivos();
                    break;
                case 3:
                    ConsultarPrestamosPorUsuario();
                    break;
                case 4:
                    ObtenerTodosLosPrestamos();
                    break;
                case 5:
                    break;
            }
        }
    }
}
