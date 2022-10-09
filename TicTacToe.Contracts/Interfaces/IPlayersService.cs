using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Contracts
{
    public interface IPlayersService
    {
        public Task<Player> AddPlayer(PlayerForCreationDto playerCreationDto);

        public Task<Player> AuthenticatePlayer(PlayerForAuthenticationDto playerForAuthenticationDto);
    }
}
