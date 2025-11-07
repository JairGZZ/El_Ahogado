using El_Ahogado.Server.enums;

namespace El_Ahogado.Server.dto
{
    public class GameResponse
    {
        public Guid GameId { get; set; }
        public string MaskedWord { get; set; }
        public int AttemtsLeft { get; set; }
        public GameStates Status { get; set; } = GameStates.IN_PROGRESS;
        public string SecretWord { get; set; }
    }
}
