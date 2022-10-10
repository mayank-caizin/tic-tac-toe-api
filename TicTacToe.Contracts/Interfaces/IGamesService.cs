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
    }
}
