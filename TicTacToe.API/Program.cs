using System.Reflection;
using Microsoft.OpenApi.Models;
using TicTacToe.API.BLL.Services;
using TicTacToe.API.DAL.Repositories;
using TicTacToe.API.DAL.Repositories.Contexts;
using TicTacToe.API.Middlewaries;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers();

services.AddDbContext<GameDbContext>();
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
            Description = "Это што",
        }
    );
    
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    options.CustomSchemaIds(x => x.FullName);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    
}

app.UseMiddleware<ErrorMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();