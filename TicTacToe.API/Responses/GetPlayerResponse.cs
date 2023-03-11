using TicTacToe.API.BLL.Models;

namespace TicTacToe.API.Responses;

/// <summary>
/// Get Player Response
/// </summary>
/// <param name="Player">Information about player</param>
public record GetPlayerResponse(Player Player);