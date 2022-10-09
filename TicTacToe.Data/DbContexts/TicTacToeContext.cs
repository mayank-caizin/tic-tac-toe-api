using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Contracts;

namespace TicTacToe.Data
{
    public class TicTacToeContext : DbContext
    {
        public TicTacToeContext(DbContextOptions<TicTacToeContext> options) : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().HasData(
                new Player()
                {
                    Id = "computer",
                    Name = "Computer",
                    Email = "computer@gmail.com",
                    Password = "12345678"
                }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
