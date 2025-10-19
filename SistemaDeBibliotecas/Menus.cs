using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeBibliotecas
{
    internal class Menus
    {
        public static int MenuPrincipal(string titulo, string[] opciones, int coordX, int coordY)
        {
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            return (MenuSeleccionPlantilla(titulo, opciones, coordX, coordY));
        }
        public static int MenuSeleccionPlantilla(string titulo, string[] opciones, int coordX, int coordY)
        {
            //Limpiar la consola y establecer colores
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            //Imprimir los bordes
            Console.SetCursorPosition(coordX, coordY);
            Console.Write("┌");
            for (int i = 1; i < 41; i++)
            {
                Console.SetCursorPosition(coordX + i, coordY);
                Console.Write("─");
            }
            Console.SetCursorPosition(coordX + 36, coordY);
            Console.Write(" - ");
            Console.SetCursorPosition(coordX + 39, coordY);
            Console.Write("■ ");
            Console.SetCursorPosition(coordX + 41, coordY);
            Console.Write("X");
            Console.SetCursorPosition(coordX, coordY + 1);
            Console.Write("│");
            for (int i = 1; i < 41; i++)
            {
                Console.SetCursorPosition(coordX + i, coordY + 1);
                Console.Write(" ");
            }
            Console.SetCursorPosition(coordX + 41, coordY + 1);
            Console.Write("│");
            Console.SetCursorPosition(coordX, coordY + 2);
            Console.Write("├");
            for (int i = 1; i < 41; i++)
            {
                Console.SetCursorPosition(coordX + i, coordY + 2);
                Console.Write("─");
            }
            Console.SetCursorPosition(coordX + 41, coordY + 2);
            Console.Write("┤");
            for (int i = 3; i < 6 + opciones.Length; i++)
            {
                Console.SetCursorPosition(coordX, coordY + i);
                Console.Write("│");
                for (int f = 1; f < 41; f++)
                {
                    Console.SetCursorPosition(coordX + f, coordY + i);
                    Console.Write(" ");
                }
                Console.SetCursorPosition(coordX + 41, coordY + i);
                Console.Write("│");
            }
            Console.SetCursorPosition(coordX, coordY + 6 + opciones.Length);
            Console.Write("└");
            for (int i = 1; i < 41; i++)
            {
                Console.SetCursorPosition(coordX + i, coordY + 6 + opciones.Length);
                Console.Write("─");
            }
            Console.SetCursorPosition(coordX + 41, coordY + 6 + opciones.Length);
            Console.Write("┘");

            //Imprimir el titulo
            coordX += 1;
            coordY += 1;
            Console.SetCursorPosition(coordX, coordY);
            Console.Write(titulo);

            //Imprimr instrucciones
            coordY += 2;
            Console.SetCursorPosition(coordX, coordY);
            Console.Write("Utiliza las flechas para moverte:");

            //Imprimir las opciones
            var key = ConsoleKey.A;
            int selectedOption = 0;
            coordY += 2;
            coordX += 1;
            while (key != ConsoleKey.Enter)
            {
                //Imprimir las opciones
                for (int i = 0; i < opciones.Length; i++)
                {
                    if (i == selectedOption)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.SetCursorPosition(coordX, coordY + i);
                    Console.WriteLine($"{i + 1}. {opciones[i]}");
                }

                //Colores para cuando se utilice una tecla incorrecta
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.BackgroundColor = ConsoleColor.Blue;

                //Leer la tecla presionada
                key = Console.ReadKey().Key;
                if (key == ConsoleKey.DownArrow)
                {
                    selectedOption++;
                    if (selectedOption >= opciones.Length)
                    {
                        selectedOption = 0;
                    }
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    selectedOption--;
                    if (selectedOption < 0)
                    {
                        selectedOption = opciones.Length - 1;
                    }
                }
            }
            Console.ResetColor();
            return selectedOption;
        }
        public static string[] MenuPreguntasLibros(string[] preguntas, int coordX, int coordY)
        {
            //Asignar colores
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            //Imprimir bordes
            Console.SetCursorPosition(coordX, coordY);
            Console.Write("┌");
            for (int i = 1; i < 50; i++)
            {
                Console.SetCursorPosition(coordX + i, coordY);
                Console.Write("─");
            }
            Console.SetCursorPosition(coordX + 50, coordY);
            Console.Write("┐");
            for (int i = 1; i < 4; i++)
            {
                Console.SetCursorPosition(coordX, coordY + i);
                Console.Write("│");
                for (int f = 1; f < 50; f++)
                {
                    Console.SetCursorPosition(coordX + f, coordY + i);
                    Console.Write(" ");
                }
                Console.SetCursorPosition(coordX + 50, coordY + i);
                Console.Write("│");
            }
            Console.SetCursorPosition(coordX, coordY + 4);
            Console.Write("└");
            for (int i = 1; i < 50; i++)
            {
                Console.SetCursorPosition(coordX + i, coordY + 4);
                Console.Write("─");
            }
            Console.SetCursorPosition(coordX + 50, coordY + 4);
            Console.Write("┘");
            Console.SetCursorPosition(coordX + 2, coordY + 1);
            Console.Write("Cuantos autores tiene el libro?");
            Console.SetCursorPosition(coordX + 2, coordY + 2);
            int numAutores;
            try 
            {
                numAutores = int.Parse(Console.ReadLine()); 
            } catch 
            {
                numAutores = 0; 
            };
            string[] nuevasPreguntas;
            nuevasPreguntas = new string[preguntas.Length + numAutores];
            Array.Copy(preguntas, nuevasPreguntas, preguntas.Length);
            for (int i = 0; i < numAutores; i++)
            {
                nuevasPreguntas[preguntas.Length + i] = $"Nombre del autor {i + 1}: ";
            }
            return MenuPreguntasPlantilla(nuevasPreguntas, coordX, coordY);
        }
        public static string[] MenuPreguntasPlantilla(string[] preguntas, int coordX, int coordY)
        {
            //Asignar colores
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            //Imprimir bordes
            Console.SetCursorPosition(coordX, coordY);
            Console.Write("┌");
            for (int i = 1; i < 50; i++)
            {
                Console.SetCursorPosition(coordX + i, coordY);
                Console.Write("─");
            }
            Console.SetCursorPosition(coordX + 50, coordY);
            Console.Write("┐");
            for (int i = 1; i < 1 + preguntas.Length * 2; i++)
            {
                Console.SetCursorPosition(coordX, coordY + i);
                Console.Write("│");
                for (int f = 1; f < 50; f++)
                {
                    if (i % 2 != 0)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(coordX + f, coordY + i);
                        Console.Write(" ");
                    }
                    else
                    {
                        if (f >= 45)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                        }
                        Console.SetCursorPosition(coordX + f, coordY + i);
                        Console.Write(" ");
                    }
                }
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(coordX + 50, coordY + i);
                Console.Write("│");
            }
            Console.SetCursorPosition(coordX, coordY + 1 + preguntas.Length * 2);
            Console.Write("└");
            for (int i = 1; i < 50; i++)
            {
                Console.SetCursorPosition(coordX + i, coordY + 1 + preguntas.Length * 2);
                Console.Write("─");
            }
            Console.SetCursorPosition(coordX + 50, coordY + 1 + preguntas.Length * 2);
            Console.Write("┘");

            //Imprimir las preguntas
            coordX += 2;
            coordY += 1;
            string[] respuestas = new string[preguntas.Length];
            for (int i = 0; i < preguntas.Length; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(coordX, coordY);
                Console.WriteLine(preguntas[i]);
                coordY++;
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(coordX, coordY);
                respuestas[i] = Console.ReadLine() ?? "";
                coordY++;
            }

            Console.ResetColor();
            return respuestas;
        }
        public static void DisplayMensaje(string mensaje, int coordX, int coordY)
        {   
            //Asignar colores
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            //Imprimir bordes
            Console.SetCursorPosition(coordX, coordY);
            Console.Write("┌");
            for (int i = 1; i < mensaje.Length + 4; i++)
            {
                Console.SetCursorPosition(coordX + i, coordY);
                Console.Write("─");
            }
            Console.SetCursorPosition(coordX + mensaje.Length - 1, coordY);
            Console.Write(" - ");
            Console.SetCursorPosition(coordX + mensaje.Length + 2, coordY);
            Console.Write("■ ");
            Console.SetCursorPosition(coordX + mensaje.Length + 4, coordY);
            Console.Write("X");
            for (int i = 1; i < 4; i++)
            {
                Console.SetCursorPosition(coordX, coordY + i);
                Console.Write("│");
                for (int f = 1; f < mensaje.Length + 4; f++)
                {
                    Console.SetCursorPosition(coordX + f, coordY + i);
                    Console.Write(" ");
                }
                Console.SetCursorPosition(coordX + mensaje.Length + 4, coordY + i);
                Console.Write("│");
            }
            Console.SetCursorPosition(coordX, coordY + 4);
            Console.Write("└");
            for (int i = 1; i < mensaje.Length + 4; i++)
            {
                Console.SetCursorPosition(coordX + i, coordY + 4);
                Console.Write("─");
            }
            Console.SetCursorPosition(coordX + mensaje.Length + 4, coordY + 4);
            Console.Write("┘");

            //Imprimir el mensaje
            Console.SetCursorPosition(coordX + 2, coordY + 1);
            Console.WriteLine(mensaje);

            //Imprimir el boton continuar
            Console.SetCursorPosition(coordX + mensaje.Length + 4 - "Aceptar".Length - 2, coordY + 3);
            Console.WriteLine("┌──── - ■ X");
            Console.SetCursorPosition(coordX + mensaje.Length + 4 - "Aceptar".Length - 2, coordY + 4);
            Console.WriteLine("│ Aceptar │");
            Console.SetCursorPosition(coordX + mensaje.Length + 4 - "Aceptar".Length - 2, coordY + 5);
            Console.WriteLine("└─────────┘");
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(coordX + mensaje.Length + 4 - "Aceptar".Length - 1, coordY + 4);
            Console.Write(" Aceptar ");
            Console.ReadKey();
        }
        public static void DisplayLibros(List<Libros> libros)
        {
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(1, 1);
            Console.WriteLine("Lista de libros disponibles:");
            int row = 3;
            if (libros.Count == 0)
            {
                Console.SetCursorPosition(1, row);
                Console.WriteLine("No hay libros registrados.");
                row++;
            }
            foreach (var libro in libros)
            {
                Console.SetCursorPosition(1, row);
                Console.Write($"ID: {libro.id} │ Nombre: {libro.nombre} │ ");
                Console.Write("Autores: ");
                foreach (var autor in libro.autores)
                {
                    Console.Write($"{autor.nombre} │ ");
                }
                Console.WriteLine($"Genero: {libro.genero.nombre}");
                row++;
            }

            //Imprimir el boton continuar
            Console.SetCursorPosition(1, row + 1);
            Console.WriteLine("┌──── - ■ X");
            Console.SetCursorPosition(1, row + 2);
            Console.WriteLine("│ Aceptar │");
            Console.SetCursorPosition(1, row + 3);
            Console.WriteLine("└─────────┘");
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(2, row + 2);
            Console.Write(" Aceptar ");
            Console.ReadKey();
        }
        public static void DisplayUsuarios(List<Usuarios> usuarios)
        {
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(1, 1);
            Console.WriteLine("Lista de usuarios:");
            int row = 3;
            if (usuarios.Count == 0)
            {
                Console.SetCursorPosition(1, row);
                Console.WriteLine("No hay usuarios registrados.");
                row++;
            }
            foreach (var usuario in usuarios)
            {
                Console.SetCursorPosition(1, row);
                Console.WriteLine($"ID: {usuario.id} │ Nombre: {usuario.nombre} │ Correo: {usuario.correo} │ Telefono: {usuario.telefono}" );
                row++;
            }

            //Imprimir el boton continuar
            Console.SetCursorPosition(1, row + 1);
            Console.WriteLine("┌──── - ■ X");
            Console.SetCursorPosition(1, row + 2);
            Console.WriteLine("│ Aceptar │");
            Console.SetCursorPosition(1, row + 3);
            Console.WriteLine("└─────────┘");
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(2, row + 2);
            Console.Write(" Aceptar ");
            Console.ReadKey();
        }
        public static void DisplayPrestamos(List<Prestamo> prestamos)
        {
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(1, 1);
            Console.WriteLine("Lista de Prestamos:");
            int row = 3;
            if (prestamos.Count == 0)
            {
                Console.SetCursorPosition(1, row);
                Console.WriteLine("No hay prestamos registrados.");
                row++;
            }
            foreach (var prestamo in prestamos)
            {
                Console.SetCursorPosition(1, row);
                Console.WriteLine($"ID: {prestamo.id} │ Usuario: {prestamo.usuario.nombre} │ Libro prestado: {prestamo.libro.nombre} │ {prestamo.fechaPrestamo}");
                row++;
            }

            //Imprimir el boton continuar
            Console.SetCursorPosition(1, row + 1);
            Console.WriteLine("┌──── - ■ X");
            Console.SetCursorPosition(1, row + 2);
            Console.WriteLine("│ Aceptar │");
            Console.SetCursorPosition(1, row + 3);
            Console.WriteLine("└─────────┘");
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(2, row + 2);
            Console.Write(" Aceptar ");
            Console.ReadKey();
        }
    }
}
