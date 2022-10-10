using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Contracts
{
    public interface IGamesRepository
    {
        Task<IEnumerable<Game>> GetGamesAsync(string playerId);

        void AddGame(Game game);

        Task<bool> SaveChangesAsync();

        Task<Game> GetGameAsync(string playerId, string gameId);
    }
}
