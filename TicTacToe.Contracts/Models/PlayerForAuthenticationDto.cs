using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Contracts
{
    public class PlayerForAuthenticationDto
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
