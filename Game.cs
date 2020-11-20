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

        public Game() {
            // Asignar intento
            Attemps = 6;
            // Asignamos la palabra secreta (luego cargamos de ficheros)
            HideWord = "Ahorcado en C Sharp";
            // Array base con los carácteres de la palabra secreta (HideWord)
            // Primero convertir a minúscula la palabra secreta y luego convertir un array de caracteres
            char [] gameWordsHideChars = (HideWord.ToLower()).ToCharArray();
            // Crear Array a partir del creado para especificar los huecos antes de rellenarlo con "_"
            // en el caso de los carácteres ocultos y en correcto con la información original
            HideWordChars = CorrectChars = new List<char>(gameWordsHideChars);

            for(int i = 0; i < HideWordChars.Count; i++) {
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

        }
    }
}