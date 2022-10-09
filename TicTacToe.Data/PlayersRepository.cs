using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Contracts;

namespace TicTacToe.Data
{
    public class PlayersRepository: IPlayersRepository
    {
        private readonly TicTacToeContext _context;

        public PlayersRepository(TicTacToeContext context)
        {
            _context = context;
        }

        public void AddPlayer(Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            _context.Players.Add(player);
        }

        public async Task<Player> GetPlayer(string email)
        {
            return await _context.Players.FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task<bool> SaveChangesAsync()
        {
            // return true if 1 or more entities were changed
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
