using System;
using System.Collections.Generic;

namespace StrangleGame
{
    class Game
    {
        // Necesitaremos
        // ====================
        // Intentos (número entero)
        public int Attemps { get; set; }
        // Palabra secreta (string)
        public string HideWord { get; set; }
        // los carácteres de la palabra del juego con lo oculto (string)
        public string GameWordsChars { get; set; }
        // Lista donde se almacenan los carácteres introducidos (Lista de carácteres)
        public List<char> InputCharsList { get; set; }
        // Lista de carácteres ocultos para controlar que faltan por acertar
        public List<char> HideWordChars { get; set; }
        // Lista de carácteres que almacena todos los carácteres de la palabra a acertar
        public List<char> CorrectChars { get; set; }
        // Teniendo en cuenta la palabra correcta, se almacena la información correcta

        public Game()
        {
            // Asignar intento
            Attemps = 6;
            // Asignamos la palabra secreta (luego cargamos de ficheros)
            HideWord = "Ahorcado";
            // Array base con los carácteres de la palabra secreta (HideWord)
            // Primero convertir a minúscula la palabra secreta y luego convertir un array de caracteres
            char[] gameWordsHideChars = (HideWord.ToLower()).ToCharArray();
            // Crear Array a partir del creado para especificar los huecos antes de rellenarlo con "_"
            // en el caso de los carácteres ocultos y en correcto con la información original
            HideWordChars = CorrectChars = new List<char>(gameWordsHideChars);
            InputCharsList = new List<char>();
            for (int i = 0; i < HideWordChars.Count; i++)
            {
                // Mirar si no hay un espacio en esa palabra. 
                // Si la hay no hacer nada en esa lista y si añadiendo en
                // el apartado de la palabra a mostrar en el ojo
                if (HideWordChars[i] != ' ')
                {
                    // Tenemos una letra para acertar
                    GameWordsChars += "_ ";
                    HideWordChars[i] = '_';
                }
                else
                {
                    GameWordsChars += "    ";
                }
            }
            // Aquí deberiamos de dibujar la primera imagen
            DrawGameImage();
            // Para tener el apartado y la pista de palabra a buscar
            Console.WriteLine("Palabra a buscar: ");
            Console.WriteLine(GameWordsChars);
        }
        /*
        Aquí es donde ya tenemos el flujo del juego en marcha mientras esté activa
        la partida hasta acertar o perder las vidas
        */
        public void Play()
        {
            // Ir usando el debugger para ir cambiando la información
            // de los intentos, así vemos que pasa cuando llega a 0
            while (Attemps > 0 && HideWordChars.Contains('_'))
            {
                Console.Write("\nIntroduzca letra: ");
                char inputChar;
                try
                {
                    inputChar = Console.ReadLine()[0];
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Introduzca un carácter válido de a-z");
                    inputChar = ' ';
                }
                // Carácter unicodes list
                if (inputChar >= 'a' && inputChar <= 'z')
                {
                    // No existe el carácter y está en
                    if (!InputCharsList.Contains(inputChar))
                    {
                        InputCharsList.Add(inputChar);
                        // Comprobar si existe el carácter en la palabra oculta

                        // Dibujar el estado del juego teniendo en cuenta los intentos y si ha acertado
                    } else if (InputCharsList.Contains(inputChar)) {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Ya has introducido el carácter {0}, prueba de nuevo", inputChar);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    
                    
                }
            }
            if (Attemps == 0)
            {
                DrawGameImage();
            }
            else if (!HideWordChars.Contains('_'))
            {
                Console.Write("Enhorabuena, has acertado la palabra oculta");
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
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"GAME OVER - La palabra a acertar era \"{HideWord}\"");
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