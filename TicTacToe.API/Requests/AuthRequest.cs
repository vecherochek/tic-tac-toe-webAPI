namespace TicTacToe.API.Requests.Auth;

/// <summary>
/// Auth Request
/// </summary>
/// <param name="Nickname">Player nickname</param>
/// <param name="Password">Player password</param>
public record AuthRequest(string Nickname, byte[] Password);