using Microsoft.EntityFrameworkCore;
using TicTacToe.Data;

namespace TicTacToe.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // builder.Services.AddDbContext<TicTacToeContext>(options => options.UseInMemoryDatabase("TicTacToeDb"));
            builder.Services.AddDbContext<TicTacToeContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("TicTacToeDbConnectionString")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}