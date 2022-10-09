using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicTacToe.Contracts
{
    public class Game
    {
        [Key]
        public string Id { get; set; }

        public string Board { get; set; } = "---------";

        public int GameMode { get; set; } = 1;

        public bool IsComplete { get; set; }

        public bool Xturn { get; set; } = true;

        //[ForeignKey("XPlayerId")]
        //public Player XPlayer { get; set; }

        //[ForeignKey("OPlayerId")]
        //public Player OPlayer { get; set; }

        [Required]
        public string XPlayerId { get; set; }

        [Required]
        public string OPlayerId { get; set; }


        public string Winner { get; set; } = "";
    }
}