using El_Ahogado.Server.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace El_Ahogado.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly GameService _gameService;
        public GameController(GameService gameService)
        {
            _gameService = gameService;
        }
        [HttpGet("newGame")]
        public async Task<IActionResult> ObtenerPalabraRamdom2([FromQuery] int? minLength = null, [FromQuery] int? maxLength = null)
        {
            return Ok(await _gameService.NewGame());
        }

        [HttpGet("makeGuess/{gameId}/{letter}")]

        public IActionResult ObtenerPalabraRamdom3([FromRoute] Guid gameId, [FromRoute] char letter)
        {
            return Ok(_gameService.MakeGuess(gameId, letter));

        }
    }
}
