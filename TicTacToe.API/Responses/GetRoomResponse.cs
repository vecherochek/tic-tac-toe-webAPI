using TicTacToe.API.BLL.Models;

namespace TicTacToe.API.Responses;

/// <summary>
/// Get Room Response
/// </summary>
/// <param name="Room">Information about room</param>
public record GetRoomResponse(Room Room);