using Microsoft.EntityFrameworkCore;
using TicTacToe.API.BLL.Models;

namespace TicTacToe.API.DAL.Repositories.Contexts;

public class PlayersDbContext : DbContext
{
    public DbSet<Player> Players { get; set; }

    public PlayersDbContext(DbContextOptions<PlayersDbContext> options)
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
        builder.Entity<Player>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.HasIndex(e => e.Nickname).IsUnique();
        });
    }
}