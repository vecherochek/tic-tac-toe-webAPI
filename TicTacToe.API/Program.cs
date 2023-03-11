using System.Reflection;
using Microsoft.OpenApi.Models;
using TicTacToe.API.BLL.Services;
using TicTacToe.API.DAL.Repositories;
using TicTacToe.API.DAL.Repositories.Contexts;
using TicTacToe.API.Middlewaries;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers();


//services.AddDbContext<GameRedisDbContext>();
services.AddDbContext<GamesDbContext>();
services.AddDbContext<PlayersDbContext>();
services.AddDbContext<RoomsDbContext>();
services.AddTransient<GameRepository>();
services.AddTransient<PlayerRepository>();
services.AddTransient<RoomRepository>();
services.AddTransient<AuthentificationService>();
services.AddTransient<PlayerService>();
services.AddTransient<GameService>();
services.AddTransient<RegistrationService>();
services.AddTransient<RoomService>();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", 
        new OpenApiInfo
        {
            Version = "v1",
            Title = "TicTacToe-Backend",
            Description = "Классный сервис, но я не советую :3",
        }
    );
    
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    options.CustomSchemaIds(x => x.FullName);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMiddleware<ErrorMiddleware>();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();