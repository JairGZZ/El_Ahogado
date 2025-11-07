using El_Ahogado.Server.enums;
using System;

namespace El_Ahogado.Server.models
{
    public class Game
    {
        public Guid gameId { get; set; } = Guid.NewGuid();
        public string secretWord { get; set; } // palabra a adivinar
        public string maskedWord { get; set; } = string.Empty;

        public int wordLength { get; set; }  // el tamaño de la palabra
        public ICollection<char> usedLetters { get; set; } = new List<char>();
        public ICollection<char> wrongLetters { get; set; } = new List<char>() ;
        public int maxAttempts { get; set; } = 6; // número máximo de intentos permitidos
        public int attemptsLeft { get; set; } = 6; // intentos restantes
        public GameStates status { get; set; } = GameStates.IN_PROGRESS; // estado del juego: IN_PROGRESS, WON, LOST
        public DateTime createdAt { get; set; } = DateTime.UtcNow; // fecha y hora de creación del juego

    }
}
