using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TicTacToe.API.BLL.Models;

/// <summary>
/// Класс, описывающий игрока
/// </summary>
public class Player
{
    /// <summary>
    /// Id игрока
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Nickname игрока (уникальный)
    /// </summary>

    public string Nickname { get; set; }

    /// <summary>
    /// Пороль от аккаунта
    /// </summary>
    [JsonIgnore]
    public byte[] SaltedPassword { get; set; }

    /// <summary>
    /// Текущий онлайн игрока
    /// </summary>
    public bool IsOnline { get; set; }
}