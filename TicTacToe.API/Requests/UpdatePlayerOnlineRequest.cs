namespace TicTacToe.API.Requests;

/// <summary>
/// Update Player Online Request
/// </summary>
/// <param name="IsOnline">Information about the online player: true or false</param>
public record UpdatePlayerOnlineRequest(bool IsOnline);