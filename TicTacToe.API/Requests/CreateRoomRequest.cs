namespace TicTacToe.API.Requests.Room;

/// <summary>
/// Create Room Request
/// </summary>
/// <param name="playerId">Player Id</param>
public record CreateRoomRequest(Guid playerId);