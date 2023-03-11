using System.ComponentModel.DataAnnotations;
using Redis.OM.Modeling;

namespace TicTacToe.API.BLL.Models;

/// <summary>
/// 
/// </summary>
public class Game
{
    /// <summary>
    /// 
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Guid PlayerXId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Guid PlayerOId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public List<Step>? Steps { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Guid? WinnerId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public bool IsFinished { get; set; }
}