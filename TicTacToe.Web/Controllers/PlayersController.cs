using Microsoft.AspNetCore.Mvc;
using TicTacToe.Contracts;

namespace TicTacToe.Web
{
    [ApiController]
    [Route("api/players")]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayersService _playersService;

        public PlayersController(IPlayersService playersService)
        {
            _playersService = playersService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer(PlayerForCreationDto player)
        {
            var playerEntity = await _playersService.AddPlayer(player);
            return Ok(playerEntity);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogInPlayer(PlayerForAuthenticationDto playerDetails)
        {
            var playerEntity = await _playersService.AuthenticatePlayer(playerDetails);

            if(playerEntity == null)
            {
                return NotFound("Login Failed");
            }

            return Ok(playerEntity);
        }
    }
}
