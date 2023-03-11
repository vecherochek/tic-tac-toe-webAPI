namespace TicTacToe.API.Requests.Auth;

public record AuthRequest(string Nickname, byte[] Password);