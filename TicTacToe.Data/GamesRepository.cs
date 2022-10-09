using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Contracts;

namespace TicTacToe.Data
{
    public class GamesRepository: IGamesRepository
    {
        private readonly TicTacToeContext _context;

        public GamesRepository(TicTacToeContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveChangesAsync()
        {
            // return true if 1 or more entities were changed
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
