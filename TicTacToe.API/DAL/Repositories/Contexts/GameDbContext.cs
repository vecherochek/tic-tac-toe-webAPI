using Microsoft.EntityFrameworkCore;
using TicTacToe.API.BLL.Models;

namespace TicTacToe.API.DAL.Repositories.Contexts;

public class GameDbContext : DbContext
{
    public DbSet<Game> Games { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Room> Rooms { get; set; }

    public GameDbContext(DbContextOptions<GameDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //захаркоженная строка это плохо, но я не смогла из докер композа сюда environment variable положить :(
        optionsBuilder.UseNpgsql("Server=192.168.1.186;Port=5432;Database=postgres;Username=postgres;Password=qwerty");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Game>(options =>
        {
            options.HasKey(x => x.Id);
            //options.OwnsOne(game => game.Steps, ownedNavigationBuilder => ownedNavigationBuilder.ToJson());
        });

        builder.Entity<Player>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.HasIndex(e => e.Nickname).IsUnique();
        });

        builder.Entity<Room>().HasKey(x => x.Id);
    }
}