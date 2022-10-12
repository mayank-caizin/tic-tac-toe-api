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

        [HttpPut("{gameId}")]
        public async Task<IActionResult> UpdateGame([FromRoute] string playerId, [FromRoute] string gameId, [FromBody] Game gameToUpdate)
        {
            if (!_playersService.PlayerExists(playerId))
            {
                return NotFound();
            }

            var game = await _gamesService.GetGameAsync(playerId, gameId);

            if (game == null)
            {
                return NotFound();
            }

            await _gamesService.UpdateGame(game, gameToUpdate);

            return NoContent();
        }

        [HttpDelete("{gameId}")]
        public async Task<IActionResult> DeleteGame([FromRoute] string playerId, [FromRoute] string gameId)
        {
            if (!_playersService.PlayerExists(playerId))
            {
                return NotFound();
            }

            var game = await _gamesService.GetGameAsync(playerId, gameId);

            if (game == null)
            {
                return NotFound();
            }

            await _gamesService.DeleteGame(game);

            return NoContent();
        }

        /*
        [HttpGet("{gameId}/move")]
        public async Task<IActionResult> GetMove([FromRoute] string playerId, [FromRoute] string gameId)
        {
            if (!_playersService.PlayerExists(playerId))
            {
                return NotFound();
            }

            var game = await _gamesService.GetGameAsync(playerId, gameId);

            if (game == null)
            {
                return NotFound();
            }

            int moveIndex = _gamesService.GetBestMove(game);

            return Ok(moveIndex);
        }

        [HttpPatch("{gameId}")]
        public async Task<IActionResult> MakeMove([FromRoute] string playerId, [FromRoute] string gameId, [FromBody] int index)
        {
            if (index > 8)
            {
                return BadRequest("Invalid Move");
            }

            if (!_playersService.PlayerExists(playerId))
            {
                return NotFound();
            }

            var game = await _gamesService.GetGameAsync(playerId, gameId);

            if (game == null)
            {
                return NotFound();
            }

            if (game.Board[index] != '_')
            {
                return BadRequest("invalid move");
            }

            await _gamesService.MakeMove(game, index);

            // await _gamesService.MakeMove(playerId, gameId, index);

            return NoContent();
        }
        */
    }
}
