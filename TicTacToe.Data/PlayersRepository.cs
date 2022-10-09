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
    }
}
