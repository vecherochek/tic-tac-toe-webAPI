using TicTacToe.API.BLL.Models;

namespace TicTacToe.API.Responses;

/// <summary>
/// Auth Response
/// </summary>
/// <param name="Player">Information about player</param>
public record AuthResponse(Player Player);