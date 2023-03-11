using TicTacToe.API.BLL.Models;

namespace TicTacToe.API.DAL.Repositories.Interface;

public interface IRoomRepository: IRepository<Room>
{
    IEnumerable<Room> GetRooms();
}