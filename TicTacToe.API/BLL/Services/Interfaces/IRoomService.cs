using TicTacToe.API.BLL.Models;

namespace TicTacToe.API.BLL.Services.Interfaces;

public interface IRoomService
{
    Guid CreateRoom(Guid playerId);
    Room GetRoom(Guid roomId);
    void LeaveRoom(Guid playerId, Guid roomId);

    void AddPlayerToRoom(Guid playerId, Guid roomId);

    Guid StartGame(Guid roomId);
}