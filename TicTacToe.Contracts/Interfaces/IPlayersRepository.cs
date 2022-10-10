using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Contracts
{
    public interface IPlayersRepository
    {
        void AddPlayer(Player player);

        Task<Player> GetPlayer(string id);

        bool PlayerExists(string playerId);

        Task<Player> GetPlayerByEmail(string email);

        Task<bool> SaveChangesAsync();
    }
}
