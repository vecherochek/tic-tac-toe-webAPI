namespace TicTacToe.API.Requests.Auth;

public record RegistrationRequest(string Nickanme, byte[] Password);