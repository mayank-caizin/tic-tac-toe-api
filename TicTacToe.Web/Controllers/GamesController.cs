using Microsoft.AspNetCore.Mvc;
using TicTacToe.Contracts;

namespace TicTacToe.Web
{
    [ApiController]
    [Route("api/players/{playerId}/games")]
    public class GamesController : ControllerBase
    {
        private readonly IGamesService _gamesService;

        public GamesController(IGamesService gamesService)
        {
            _gamesService = gamesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetGames([FromRoute] string playerId)
        {
            var games = await _gamesService.GetGamesAsync(playerId);
            return Ok(games);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGame([FromRoute] string playerId, [FromQuery] int gameMode)
        {
            var gameEntity = await _gamesService.AddGame(playerId, gameMode);
            return Ok(gameEntity);
        }
    }
}
