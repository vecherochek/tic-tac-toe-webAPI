using TicTacToe.API.BLL.Models;

namespace TicTacToe.API.Responses;

/// <summary>
/// Get Player Score Response
/// </summary>
/// <param name="PlayerScore">Information about player's score</param>
public record GetPlayerScoreResponse(PlayerScore PlayerScore);