using TicTacToe.API.BLL.Models;

namespace TicTacToe.API.BLL.Services.Interfaces;

public interface IAuthentificationService
{
    bool IsExists(string nickname);

    Player GetPlayerByAuthData(string nickname, byte[] password);
}