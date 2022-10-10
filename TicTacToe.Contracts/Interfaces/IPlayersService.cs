using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Contracts
{
    public interface IPlayersService
    {
        bool PlayerExists(string playerId);

        Task<Player> AddPlayer(PlayerForCreationDto playerCreationDto);

        Task<Player> AuthenticatePlayer(PlayerForAuthenticationDto playerForAuthenticationDto);
    }
}
