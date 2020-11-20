using System;

namespace StrangleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Menú 

            string optionSelect = "";
            do
            {
                Console.WriteLine("===============AHORCADO en C#===============");
                Console.WriteLine("");
                if (optionSelect == "--")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Seleccione una de las opciones disponibles por favor.");
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Opciones del juego: ");
                Console.WriteLine("1 ) Jugar partida aleatoria con todos los temas.");
                Console.WriteLine("2 ) Jugar partida eligiendo tema.");
                Console.WriteLine("3 ) Créditos del autor.");
                Console.WriteLine("X ) Salir del juego.");
                optionSelect = Console.ReadLine();
                switch (optionSelect)
                {
                    case "1":
                        Console.WriteLine("Vamos a jugar partida aleatoria");
                        break;
                    case "2":
                        Console.WriteLine("Vamos a jugar partida eligiendo tema");
                        break;
                    case "3":
                        Console.WriteLine("Creador del juego - Anartz Mugika Ledo (mugan86@gmail.com)");
                        Console.WriteLine("Curso \"Master en Programación C# con Visual Studio Code\"");
                        Console.WriteLine("https://cursos.anartz-mugika.com/master-c-sharp-vsc");
                        break;
                    case "X":
                    case "x":
                        Console.WriteLine("¡¡Saliendo del juego!!");
                        break;
                    default:
                        optionSelect = "--";
                        Console.Clear(); // Limpiar consola
                        break;
                }
            } while (optionSelect == "--");
        }
    }
}
