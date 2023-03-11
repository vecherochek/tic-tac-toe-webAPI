using Microsoft.EntityFrameworkCore;
using TicTacToe.API.BLL.Models;
using TicTacToe.API.DAL.Repositories.Contexts;
using TicTacToe.API.DAL.Repositories.Interface;

namespace TicTacToe.API.DAL.Repositories;

public class PlayerRepository
    : Repository<Player>, IPlayerRepository
{
    private PlayersDbContext DbContext { get; set; } // not cool

    public DbSet<Player> Players => DbContext.Players;

    public PlayerRepository(PlayersDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public override Player? Get(Guid id)
    {
        return Players
            .FirstOrDefault(game => game.Id == id);
    }

    public override void Create(Player item)
    {
        Players.Add(item);
    }

    public override void Update(Player item)
    {
        Players.Update(item);
    }

    public override void Delete(Guid id)
    {
        var game = Get(id);
        if (game != null)
            Players.Remove(game);
    }

    public override void Save()
    {
        DbContext.SaveChanges();
    }

    public IEnumerable<Player> GetPlayers()
    {
        return Players.ToList();
    }

    public Player? GetPlayerByNickname(string nickname)
    {
        return Players.FirstOrDefault(player => player.Nickname == nickname);
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