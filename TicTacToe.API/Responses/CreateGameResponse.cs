namespace TicTacToe.API.Responses;

/// <summary>
/// Create Game Response
/// </summary>
/// <param name="GameId">Game Id</param>
public record CreateGameResponse(Guid GameId);