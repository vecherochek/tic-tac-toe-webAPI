using TicTacToe.API.BLL.Models;

namespace TicTacToe.API.Responses;

/// <summary>
/// Get All Players List Response
/// </summary>
/// <param name="Players">List of all players</param>
public record GetAllPlayersListResponse(IEnumerable<Player> Players);