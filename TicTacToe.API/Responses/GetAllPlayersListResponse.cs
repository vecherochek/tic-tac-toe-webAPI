using TicTacToe.API.BLL.Models;

namespace TicTacToe.API.Responses;

public record GetAllPlayersListResponse(IEnumerable<Player> Players);