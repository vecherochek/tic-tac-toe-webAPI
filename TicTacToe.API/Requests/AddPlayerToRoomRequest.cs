namespace TicTacToe.API.Requests;

/// <summary>
/// Add Player To Room Request
/// </summary>
/// <param name="playerId">Player Id</param>
public record AddPlayerToRoomRequest(Guid playerId);