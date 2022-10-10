using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        public void AddGame(Game game)
        {
            if (game == null)
            {
                throw new ArgumentNullException(nameof(game));
            }
            _context.Games.Add(game);
        }

        public async Task<Game> GetGameAsync(string playerId, string gameId)
        {
            Game? game = await _context.Games
              .Where(g => g.XPlayerId == playerId && g.Id == gameId).FirstOrDefaultAsync();

            return game;
        }

        public async Task<IEnumerable<Game>> GetGamesAsync(string playerId)
        {
            if (playerId == "" || playerId == null)
            {
                throw new ArgumentNullException(nameof(playerId));
            }

            return await _context.Games
                        .Where(g => g.XPlayerId == playerId).ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            // return true if 1 or more entities were changed
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
