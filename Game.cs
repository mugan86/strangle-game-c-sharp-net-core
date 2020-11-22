using System;
using System.Collections.Generic;
using System.IO;

namespace StrangleGame
{
    class Game
    {
        // Vamos a añadir las propiedades del juego ahorcado
        // Intentos necesarios
        public int Attemps { get; set; } // Por defecto 6
        // Palabra secreta
        public string HideWord { get; set; }
        // Palabra oculta "encriptada"
        public string GameWordChardsShow { get; set; }

        // Listas para el flujo del juego
        public List<char> InputCharsList { get; set; }
        public List<char> HideWordChars { get; set; } // se almacenan por defecto así => "_"
        public List<char> CorrectChars { get; set; } // anartz => 'a', 'n', 'a', 'r', 't', 'z'
        public Game() {
            // Intentos por defecto 6
            Attemps = 6;
            // Añadimos palabra oculta fija
            HideWord = GetHideWord();
            // Convertir el string en un array de carácteres para aplicar las listas necesarias
            char [] charListElements = (HideWord.ToLower()).ToCharArray();

            // Inicializar lista para los carácteres que vamos introduciendo
            InputCharsList = new List<char>();

            HideWordChars = new List<char>(charListElements);

            CorrectChars = new List<char>(charListElements);

            for(int i = 0; i < HideWordChars.Count; i++) {
                if (HideWordChars[i] != ' ') {
                    HideWordChars[i] = '_';
                    GameWordChardsShow += "_ ";
                } else {
                    GameWordChardsShow += "  ";
                }
            }
            DrawGameImage();
            DrawHideWord();
        }
        public void Play() {
            // Mientras jugamos
            while(Attemps > 0 && HideWordChars.Contains('_')) {
                // Introducir el carácter desde la consola con el teclado
                char inputChar = ' ';
                Console.Write("\nIntroduzca la letra: ");
                try {
                    inputChar = Console.ReadLine().ToLower() [0];
                } catch(IndexOutOfRangeException) {
                    Console.WriteLine("Debes de añadir algo de información");
                    inputChar = '.';
                } catch (Exception e) {
                    Console.WriteLine("Error general {0}", e);
                }

                // Conprobar que es un carácter válido
                if (inputChar >= 'a' && inputChar <= 'z') {
                    Console.WriteLine("Caracter válido, empezaremos con las comprobaciones");
                    // Comprobar si ese caracter se ha introducido
                    if (!InputCharsList.Contains(inputChar)) {
                        Console.Clear();
                        // Añadir para no repetir caracteres
                        InputCharsList.Add(inputChar);
                        // Comprobar si existe en la palabra oculta
                        CheckExistCharInWord(inputChar);
                        // Dibujar el estado dependiendo del resultado dado en la comprobación
                        DrawGameImage();
                        DrawHideWord();
                    } else {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Ya has introducido el caracter '{0}'. Prueba de nuevo por favor con otro caracter", inputChar);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
            // Partida finalizada
            if (Attemps == 0) {
                DrawGameImage();
            } else if (!HideWordChars.Contains('_')) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Enhorabuena, has ganado");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        private List<string> LoadWords() {
            string loadDataText = File.ReadAllText("data/sagas-miticas.txt");
            string [] words = loadDataText.Split("\n");
            return new List<string>(words); // Esto luego devolvemos una lista
        }

        private string GetHideWord() {
            // Obtener la lista de palabras
            List<string> hideWords = LoadWords();
            // https://docs.microsoft.com/es-es/dotnet/api/system.random.next?view=netcore-3.1
            Random rnd = new Random();
            // Seleccionar palabra teniendo en cuenta una posición aleatoria
            return hideWords[rnd.Next(0, hideWords.Count)]; 
        }
        private void DrawHideWord() {
            Console.WriteLine("Palabra a buscar: ");
            Console.WriteLine(GameWordChardsShow);
        }
        private void CheckExistCharInWord(char inputChar) {
            // Comprobar que existe dentro de CorrectChars
            if (CorrectChars.Contains(inputChar)) {
                // Hemos acertado
                Console.WriteLine("Has acertado :).");
                GameWordChardsShow = "";
                for(int i = 0; i < HideWordChars.Count; i++) {
                    if (CorrectChars[i] == inputChar) {
                        HideWordChars[i] = inputChar;
                    }
                    GameWordChardsShow += (HideWordChars[i] != ' ') ? HideWordChars[i] + " " : "   ";
                }

            } else {
                // NO hemos acertado
                Attemps--;
                Console.WriteLine("No has acertadp, lo siento :(");
            }
        }
        private void DrawGameImage()
        {
            Console.WriteLine("====================");
            Console.WriteLine($"Intentos: {Attemps}");
            Console.WriteLine("====================");
            switch (Attemps)
            {
                case 6:
                    Console.WriteLine(" ---------------------");
                    for (int j = 0; j <= 15; j++)
                    {
                        Console.WriteLine(" |");

                    }
                    Console.WriteLine("__________");
                    break;

                case 5:
                    Console.WriteLine(" ---------------------");
                    Console.WriteLine(" |                     |");
                    Console.WriteLine(" |                     |");
                    Console.WriteLine(" |                  -------");
                    Console.WriteLine(" |                 | -  -  |");
                    Console.WriteLine(" |                 |   o   |");
                    Console.WriteLine(" |                  -------");
                    for (int j = 0; j <= 10; j++)
                    {
                        Console.WriteLine(" |");

                    }
                    Console.WriteLine("__________");
                    break;

                case 4:
                    Console.WriteLine(" ---------------------");
                    Console.WriteLine(" |                     |");
                    Console.WriteLine(" |                     |");
                    Console.WriteLine(" |                  -------");
                    Console.WriteLine(" |                 | -  -  |");
                    Console.WriteLine(" |                 |   o   |");
                    Console.WriteLine(" |                  -------");
                    Console.WriteLine(" |                     |   ");
                    Console.WriteLine(" |                     |   ");
                    Console.WriteLine(" |                     |   ");
                    Console.WriteLine(" |                     |   ");
                    Console.WriteLine(" |                     |   ");
                    for (int j = 0; j <= 5; j++)
                    {
                        Console.WriteLine(" |");

                    }
                    Console.WriteLine("__________");
                    break;

                case 3:
                    Console.WriteLine(" ---------------------");
                    Console.WriteLine(" |                     |");
                    Console.WriteLine(" |                     |");
                    Console.WriteLine(" |                  -------");
                    Console.WriteLine(" |                 | -  -  |");
                    Console.WriteLine(" |                 |   o   |");
                    Console.WriteLine(" |                  -------");
                    Console.WriteLine(" |                     |   ");
                    Console.WriteLine(" |                   / |   ");
                    Console.WriteLine(" |                 /   |   ");
                    Console.WriteLine(" |                /    |   ");
                    Console.WriteLine(" |                     |   ");
                    for (int j = 0; j <= 5; j++)
                    {
                        Console.WriteLine(" |");

                    }
                    Console.WriteLine("__________");
                    break;

                case 2:
                    Console.WriteLine(" ---------------------");
                    Console.WriteLine(" |                     |");
                    Console.WriteLine(" |                     |");
                    Console.WriteLine(" |                  -------");
                    Console.WriteLine(" |                 | -  -  |");
                    Console.WriteLine(" |                 |   o   |");
                    Console.WriteLine(" |                  -------");
                    Console.WriteLine(" |                     |   ");
                    Console.WriteLine(" |                   / | \\ ");
                    Console.WriteLine(" |                  /  |   \\ ");
                    Console.WriteLine(" |                 /   |     \\ ");
                    Console.WriteLine(" |                     |   ");
                    for (int j = 0; j <= 5; j++)
                    {
                        Console.WriteLine(" |");

                    }
                    Console.WriteLine("__________");
                    break;

                case 1:
                    Console.WriteLine(" ---------------------");
                    Console.WriteLine(" |                     |");
                    Console.WriteLine(" |                     |");
                    Console.WriteLine(" |                  -------");
                    Console.WriteLine(" |                 | -  -  |");
                    Console.WriteLine(" |                 |   o   |");
                    Console.WriteLine(" |                  -------");
                    Console.WriteLine(" |                     |   ");
                    Console.WriteLine(" |                   / | \\ ");
                    Console.WriteLine(" |                  /  |   \\ ");
                    Console.WriteLine(" |                 /   |     \\ ");
                    Console.WriteLine(" |                     |   ");
                    Console.WriteLine(" |                    /  ");
                    Console.WriteLine(" |                   /      ");
                    Console.WriteLine(" |                  /       ");
                    for (int j = 0; j <= 2; j++)
                    {
                        Console.WriteLine(" |");

                    }
                    Console.WriteLine("__________");
                    break;

                case 0:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"GAME OVER - La palabra oculta es \"{HideWord}\"");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ---------------------");
                    Console.WriteLine(" |                     |");
                    Console.WriteLine(" |                     |");
                    Console.WriteLine(" |                  -------");
                    Console.WriteLine(" |                 | X  X  |");
                    Console.WriteLine(" |                 |   o   |");
                    Console.WriteLine(" |                  -------");
                    Console.WriteLine(" |                     |   ");
                    Console.WriteLine(" |                   / | \\ ");
                    Console.WriteLine(" |                  /  |   \\ ");
                    Console.WriteLine(" |                 /   |     \\ ");
                    Console.WriteLine(" |                     |   ");
                    Console.WriteLine(" |                    / \\");
                    Console.WriteLine(" |                   /   \\  ");
                    Console.WriteLine(" |                  /     \\ ");
                    for (int j = 0; j <= 2; j++)
                    {
                        Console.WriteLine(" |");

                    }
                    Console.WriteLine("__________");
                    
                    break;
            }
        }
    }
}
