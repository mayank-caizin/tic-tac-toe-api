using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Contracts
{
    public interface IGamesService
    {
        Task<IEnumerable<Game>> GetGamesAsync(string playerId);

        Task<Game> AddGame(string playerId, int gameMode);

        Task<Game> GetGameAsync(string playerId, string gameId);

        int GetBestMove(Game game);

        Task MakeMove(Game game, int index);

        Task MakeMove(string playerId, string gameId, int index);

        Task DeleteGame(Game game);
    }
}
