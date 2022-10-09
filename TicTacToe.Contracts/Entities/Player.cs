using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Contracts
{
    public class Player
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string Password { get; set; }

        public ICollection<Game> Games { get; set; }
            = new List<Game>();
    }
}
