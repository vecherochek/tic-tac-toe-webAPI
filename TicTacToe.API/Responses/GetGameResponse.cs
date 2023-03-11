using TicTacToe.API.BLL.Models;

namespace TicTacToe.API.Responses;

/// <summary>
/// Get Game Response
/// </summary>
/// <param name="Game">Information about game</param>
public record GetGameResponse(Game Game);