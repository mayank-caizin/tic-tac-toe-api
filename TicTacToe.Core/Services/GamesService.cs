using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Contracts;

namespace TicTacToe.Core
{
    public class GamesService : IGamesService
    {
        private readonly IGamesRepository _gamesRepository;
        private readonly IPlayersRepository _playersRepository;

        public GamesService(IGamesRepository gamesRepository, IPlayersRepository playersRepository)
        {
            _gamesRepository = gamesRepository;
            _playersRepository = playersRepository;
        }

        public async Task<Game> AddGame(string playerId, int gameMode)
        {
            Game game = new Game() {
                Id = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Replace("=", "").Replace("+", "-").Replace("/", "_"),
                XPlayerId = playerId,
                GameMode = gameMode
            };
            if(game.GameMode == (int)GameModes.AgainstComputer)
            {
                game.OPlayerId = "computer";
            }

            _gamesRepository.AddGame(game);
            Player player = await _playersRepository.GetPlayer(playerId);
            player.Games.Add(game);

            await _gamesRepository.SaveChangesAsync();

            return game;
        }

        public async Task<IEnumerable<Game>> GetGamesAsync(string playerId)
        {
            return await _gamesRepository.GetGamesAsync(playerId);
        }
    }
}
