using System.ComponentModel.DataAnnotations.Schema;

namespace TicTacToe.API.BLL.Models;

/// <summary>
/// Class describing the room
/// </summary>
public class Room
{
    /// <summary>
    /// Room Id
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Room Players. Stored as json in the database
    /// </summary>
    [Column(TypeName = "jsonb")] public RoomPlayers RoomPlayers;

    /// <summary>
    /// Room Games
    /// </summary>
    public List<Game> Games { get; set; }
}