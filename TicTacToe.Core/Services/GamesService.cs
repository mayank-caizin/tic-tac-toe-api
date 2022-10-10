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

        public int GetBestMove(Game game)
        {
            char player = game.Xturn ? 'X' : 'O';

            GameLogic gameLogic = new GameLogic(game.Board, player);

            return gameLogic.FindBestMove();
        }

        public async Task<Game> GetGameAsync(string playerId, string gameId)
        {
            if (playerId == "" || playerId == null)
            {
                throw new ArgumentNullException(nameof(playerId));
            }

            if (gameId == "" || gameId == null)
            {
                throw new ArgumentNullException(nameof(gameId));
            }

            return await _gamesRepository.GetGameAsync(playerId, gameId);
        }

        public async Task<IEnumerable<Game>> GetGamesAsync(string playerId)
        {
            return await _gamesRepository.GetGamesAsync(playerId);
        }

        public async Task MakeMove(Game game, int index)
        {
            char toReplace = game.Xturn ? 'X' : 'O';
            game.Board = game.Board.ReplaceAt(index, toReplace);
            game.Xturn = !game.Xturn;

            _gamesRepository.UpdateGame(game);

            await _gamesRepository.SaveChangesAsync();
        }

        public async Task MakeMove(string playerId, string gameId, int index)
        {
            var game = await GetGameAsync(playerId, gameId);

            if(game == null)
            {
                throw new ArgumentNullException(nameof(game));
            }

            char toReplace = game.Xturn ? 'X' : 'O';
            game.Board = game.Board.ReplaceAt(index, toReplace);
            game.Xturn = !game.Xturn;

            _gamesRepository.UpdateGame(game);

            await _gamesRepository.SaveChangesAsync();
        }
    }
}
