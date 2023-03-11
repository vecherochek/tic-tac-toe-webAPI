using TicTacToe.API.BLL.Enums;

namespace TicTacToe.API.BLL.Models;

/// <summary>
/// Class describing the step
/// </summary>
public class Step
{
    /// <summary>
    /// Id of the player who made the move
    /// </summary>
    public Guid OwnerId { get; set; }

    /// <summary>
    /// Figure type
    /// </summary>
    public FigureType Type { get; set; }

    /// <summary>
    /// Cell
    /// </summary>
    public Cell Cell { get; set; }
}