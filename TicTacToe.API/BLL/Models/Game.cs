using System.ComponentModel.DataAnnotations.Schema;

namespace TicTacToe.API.BLL.Models;

/// <summary>
/// Класс, содержащий информацию о игре
/// </summary>
public class Game
{
    /// <summary>
    /// Id игры
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Id игрока, играющего за X
    /// </summary>
    public Guid PlayerXId { get; set; }

    /// <summary>
    /// Id игрока, играющего за O
    /// </summary>
    public Guid PlayerOId { get; set; }

    /// <summary>
    /// Список шагов, сделанных за игру. В бд хранится в формате Json
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<Step>? Steps { get; set; }

    /// <summary>
    /// Id игрока, победившего в игре. Если ничья, то Id нулевой
    /// </summary>
    public Guid? WinnerId { get; set; }

    /// <summary>
    /// Текущее состояние игры: закончена или продолжается
    /// </summary>
    public bool IsFinished { get; set; }
}