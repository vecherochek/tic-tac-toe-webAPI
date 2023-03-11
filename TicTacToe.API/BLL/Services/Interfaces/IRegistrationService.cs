using TicTacToe.API.BLL.Models;

namespace TicTacToe.API.BLL.Services.Interfaces;

public interface IRegistrationService
{
    void CreateNewPlayer(string name, byte[] password);
}