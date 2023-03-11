namespace TicTacToe.API.Requests;

/// <summary>
/// Auth Request
/// </summary>
/// <param name="Nickname">Player nickname</param>
/// <param name="Password">Player password</param>
public record AuthRequest(string Nickname, byte[] Password);