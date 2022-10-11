using Microsoft.EntityFrameworkCore;
using TicTacToe.Contracts;
using TicTacToe.Core;
using TicTacToe.Data;

namespace TicTacToe.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin()
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                                  });
            });

            // Add services to the container.

            builder.Services.AddControllers();

            // builder.Services.AddDbContext<TicTacToeContext>(options => options.UseInMemoryDatabase("TicTacToeDb"));
            builder.Services.AddDbContext<TicTacToeContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("TicTacToeDbConnectionString")));

            builder.Services.AddScoped<IPlayersRepository, PlayersRepository>();
            builder.Services.AddScoped<IPlayersService, PlayersService>();

            builder.Services.AddScoped<IGamesRepository, GamesRepository>();
            builder.Services.AddScoped<IGamesService, GamesService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}