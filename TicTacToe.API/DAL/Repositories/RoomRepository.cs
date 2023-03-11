using Microsoft.EntityFrameworkCore;
using TicTacToe.API.BLL.Models;
using TicTacToe.API.DAL.Repositories.Contexts;
using TicTacToe.API.DAL.Repositories.Interface;

namespace TicTacToe.API.DAL.Repositories;

public class RoomRepository
    : Repository<Room>, IRoomRepository
{
    private GameDbContext DbContext { get; set; }

    public DbSet<Room> Rooms => DbContext.Rooms;

    public RoomRepository(GameDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public override Room? Get(Guid id)
    {
        return Rooms.FirstOrDefault(room => room.Id == id);
    }

    public override void Create(Room item)
    {
        Rooms.Add(item);
    }

    public override void Update(Room item)
    {
        Rooms.Update(item);
    }

    public override void Delete(Guid id)
    {
        var game = Get(id);
        if (game != null)
            Rooms.Remove(game);
    }

    public override void Save()
    {
        DbContext.SaveChanges();
    }

    public IEnumerable<Room> GetRooms()
    {
        return Rooms.ToList();
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