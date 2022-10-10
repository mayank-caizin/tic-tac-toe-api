using Microsoft.AspNetCore.Mvc;
using TicTacToe.Contracts;

namespace TicTacToe.Web
{
    [ApiController]
    [Route("api/players/{playerId}/games")]
    public class GamesController : ControllerBase
    {
        private readonly IGamesService _gamesService;
        private readonly IPlayersService _playersService;

        public GamesController(IGamesService gamesService, IPlayersService playersService)
        {
            _gamesService = gamesService;
            _playersService = playersService;
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
            if (!_playersService.PlayerExists(playerId))
            {
                return NotFound();
            }

            var gameEntity = await _gamesService.AddGame(playerId, gameMode);
            return Ok(gameEntity);
        }

        [HttpGet("{gameId}")]
        public async Task<IActionResult> GetGame([FromRoute] string playerId, [FromRoute] string gameId)
        {
            if (!_playersService.PlayerExists(playerId))
            {
                return NotFound();
            }

            var game = await _gamesService.GetGameAsync(playerId, gameId);

            if(game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }
    }
}
