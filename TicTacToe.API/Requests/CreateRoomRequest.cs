namespace TicTacToe.API.Requests;

/// <summary>
/// Create Room Request
/// </summary>
/// <param name="playerId">Player Id</param>
public record CreateRoomRequest(Guid playerId);