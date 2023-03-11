using TicTacToe.API.BLL.Models;

namespace TicTacToe.API.BLL.Services.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IRegistrationService
{
    /// <summary>
    /// Creates player
    /// </summary>
    /// <param name="name">nickname</param>
    /// <param name="password">salted hash on client side</param>
    /// <returns>Player object that was created if player with such <paramref name="name"/> is not exist</returns>
    void CreateNewPlayer(string name, byte[] password);
}