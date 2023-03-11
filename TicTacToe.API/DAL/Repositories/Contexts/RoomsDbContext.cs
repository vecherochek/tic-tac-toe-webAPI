using Microsoft.EntityFrameworkCore;
using TicTacToe.API.BLL.Models;

namespace TicTacToe.API.DAL.Repositories.Contexts;

public class RoomsDbContext : DbContext
{
    public DbSet<Room> Rooms { get; set; }

    public RoomsDbContext(DbContextOptions<RoomsDbContext> options)
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
        builder.Entity<Room>().HasKey(x => x.Id);
    }
}