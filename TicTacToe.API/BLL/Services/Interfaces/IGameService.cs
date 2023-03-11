using TicTacToe.API.BLL.Models;

namespace TicTacToe.API.BLL.Services.Interfaces;

public interface IGameService
{
    bool MakeStep(Guid gameId, Step step);
    Game GetGame(Guid gameId);
}