using Microsoft.EntityFrameworkCore;
using TicTacToe.API.BLL.Models;

namespace TicTacToe.API.DAL.Repositories.Contexts;

public class GamesDbContext : DbContext
{
    public DbSet<Game> Games { get; set; }

    public GamesDbContext(DbContextOptions<GamesDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=tic-tac-toe-db;Username=postgres;Password=qwerty");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Game>(options =>
        {
            options.HasKey(x => x.Id);
            options.OwnsOne(game => game.Steps, ownedNavigationBuilder => ownedNavigationBuilder.ToJson());
        });
    }
}