namespace TicTacToe.API.Requests;

/// <summary>
/// Registration Request
/// </summary>
/// <param name="Nickanme">Player nickname</param>
/// <param name="Password">Player nickname</param>
public record RegistrationRequest(string Nickanme, string Password);