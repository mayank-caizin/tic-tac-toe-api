using TicTacToe.Contracts;

namespace TicTacToe.Web
{
    public static class BookTranslator
    {
        public static PlayerDto Translate(this Player player)
        {
            return new PlayerDto
            {
                Id = player.Id,
                Name = player.Name,
                Email = player.Email
            };
        }
    }
}
