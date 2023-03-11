using TicTacToe.API.BLL.Models;

namespace TicTacToe.API.DAL.Repositories.Interface;

public interface IPlayerRepository : IRepository<Player>
{
    IEnumerable<Player> GetPlayers();

    Player? GetPlayerByNickname(string nickname);
}