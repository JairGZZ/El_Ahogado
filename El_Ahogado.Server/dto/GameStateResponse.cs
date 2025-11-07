using El_Ahogado.Server.enums;

namespace El_Ahogado.Server.dto
{
    public class GameStateResponse
    {
        public string MaskedWord { get; set; }
        public ICollection<char> UsedLetters { get; set; } = new List<char>();
        public int AttemptsLeft { get; set; }
        public GameStates Status { get; set; } = GameStates.IN_PROGRESS;
    }
}
