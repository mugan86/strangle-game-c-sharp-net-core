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
    }
}