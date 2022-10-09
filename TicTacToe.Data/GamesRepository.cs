﻿using System;
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
    }
}