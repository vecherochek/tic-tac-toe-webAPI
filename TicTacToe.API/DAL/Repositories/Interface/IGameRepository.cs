using TicTacToe.API.BLL.Models;

namespace TicTacToe.API.DAL.Repositories.Interface;

public interface IGameRepository : IRepository<Game>
{
    IEnumerable<Game> GetGames();
}