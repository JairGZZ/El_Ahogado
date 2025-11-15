namespace El_Ahogado.Server.services;

using El_Ahogado.Server.dto;
using El_Ahogado.Server.models;
using El_Ahogado.Server.services;
using El_Ahogado.Server.utils;
using System.Text;

public class GameService
{
    private readonly ApiService _apiService;
    private readonly Dictionary<Guid, Game> _games = new();


    public GameService(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<GameResponse> NewGame()
    {


        var secretWord = await _apiService.GetRandomWordAsync();

        var newGame = new Game
        {
            secretWord = secretWord,
            wordLength = secretWord.Length,
            maxAttempts = 5,
            maskedWord = WordUtils.ConvertToMasked(secretWord)
        };

        _games.Add(newGame.gameId, newGame);

        return new GameResponse{
            Status = newGame.status,
            GameId = newGame.gameId,
            AttemtsLeft = newGame .attemptsLeft,
            MaskedWord = newGame.maskedWord,
            SecretWord = newGame.secretWord
            
        }
        ;
    }
    private string BuildMaskedWord(string secretWord, ICollection<char> usedLetters)
    {
        var sb = new StringBuilder();
        var normalizedWord = WordUtils.RemoveAccents(secretWord);
        foreach (var c in normalizedWord)
        {
            sb.Append(usedLetters.Contains(c) ? c : '_');
        }
        return sb.ToString();
    }

    public Game? GetGameById(Guid gameId)
    {
        
        return _games.GetValueOrDefault(gameId);
    }


    public GameStateResponse  MakeGuess(Guid gameId, char letter)
    {
        var game = GetGameById(gameId);

        game.usedLetters.Add(letter);
        game.maskedWord = BuildMaskedWord(game.secretWord, game.usedLetters);
        game.attemptsLeft = game.attemptsLeft - 1;


        if(game.attemptsLeft == 0)
        {
            game.status = enums.GameStates.GAME_OVER;
        }
        if (game.maskedWord
        .Equals(WordUtils.RemoveAccents(game.secretWord), StringComparison.Ordinal))
        {
            game.status = enums.GameStates.WON;
        }
        return new GameStateResponse
        {
            MaskedWord = game.maskedWord,
            Status = game.status,
            AttemptsLeft = game.attemptsLeft,
            UsedLetters = game.usedLetters
        };
    }

    

}
