using Microsoft.EntityFrameworkCore;
using TicTacToe.API.BLL.Models;
using TicTacToe.API.DAL.Repositories.Contexts;
using TicTacToe.API.DAL.Repositories.Interface;

namespace TicTacToe.API.DAL.Repositories;

public sealed class GameRepository
    : Repository<Game>, IGameRepository
{
    private GameDbContext DbContext { get; set; }

    public DbSet<Game> Games => DbContext.Games;

    public GameRepository(GameDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public override Game? Get(Guid id)
    {
        return Games
            .FirstOrDefault(game => game.Id == id);
    }

    public override void Create(Game item)
    {
        Games.Add(item);
    }

    public override void Update(Game item)
    {
        Games.Update(item);
    }

    public override void Delete(Guid id)
    {
        var game = Get(id);
        if (game != null)
            Games.Remove(game);
    }

    public override void Save()
    {
        DbContext.SaveChanges();
    }

    public IEnumerable<Game> GetGames()
    {
        return Games.ToList();
    }

    protected override void Dispose(bool dispose)
    {
        if (Disposed)
            return;

        if (dispose)
        {
            DbContext.Dispose();
        }

        DbContext = null;

        dispose = true;
    }
}