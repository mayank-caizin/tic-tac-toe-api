using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Contracts;

namespace TicTacToe.Core
{
    public class PlayersService : IPlayersService
    {
        private readonly IPlayersRepository _playersRepository;

        public PlayersService(IPlayersRepository playersRepository)
        {
            _playersRepository = playersRepository;
        }

        public bool PlayerExists(string playerId)
        {
            if (playerId == null)
            {
                throw new ArgumentNullException(nameof(playerId));
            }

            return _playersRepository.PlayerExists(playerId);
        }

        public async Task<Player> AddPlayer(PlayerForCreationDto playerCreationDto)
        {
            Player player = new Player()
            {
                Id = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Replace("=", "").Replace("+", "-").Replace("/", "_"),
                Name = playerCreationDto.Name,
                Email = playerCreationDto.Email,
                Password = playerCreationDto.Password
            };

            _playersRepository.AddPlayer(player);

            await _playersRepository.SaveChangesAsync();

            return player;
        }

        public async Task<Player> AuthenticatePlayer(PlayerForAuthenticationDto playerForAuthenticationDto)
        {
            Player player = await _playersRepository.GetPlayerByEmail(playerForAuthenticationDto.Email);

            if (player == null || player.Password != playerForAuthenticationDto.Password)
            {
                return null;
            }

            return player;
        }
    }
}
