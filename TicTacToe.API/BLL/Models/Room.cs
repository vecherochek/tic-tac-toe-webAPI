using Redis.OM.Modeling;

namespace TicTacToe.API.BLL.Models;

/// <summary>
/// 
/// </summary>

public class Room
{
    /// <summary>
    /// 
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public List<Player> Players { get; set; } = new (2);
    
    /// <summary>
    /// 
    /// </summary>
    public List<Game> Games { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public RoomScore Score { get; set; }
}