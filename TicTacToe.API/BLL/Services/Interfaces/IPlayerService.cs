using TicTacToe.API.BLL.Models;

namespace TicTacToe.API.BLL.Services.Interfaces;

public interface IPlayerService
{
    Player GetPlayerById(Guid id);
    IEnumerable<Player> GetAllPlayers();
    void UpdatePlayerOnline(Guid id, bool isOnline);
    void DeletePlayer(Guid id);
    PlayerScore GetPlayerScoreByNickname(string nickname);
    PlayerScore GetPlayerScoreById(Guid id);
}