using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Contracts;

namespace TicTacToe.Core.Services
{
    public class GamesService
    {
        private readonly IGamesRepository _gamesRepository;

        public GamesService(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }
    }
}
