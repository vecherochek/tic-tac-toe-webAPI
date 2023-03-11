namespace TicTacToe.API.BLL.Models;

/// <summary>
/// A class for storing players
/// </summary>
public class RoomPlayers
{
    /// <summary>
    /// List of the players
    /// </summary>
    public List<Player> Players { get; set; } = new(2);
}