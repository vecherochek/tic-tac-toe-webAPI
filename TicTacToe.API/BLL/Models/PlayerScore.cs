namespace TicTacToe.API.BLL.Models;

/// <summary>
/// Класс, описывающий счет игрока
/// </summary>
public class PlayerScore
{
    /// <summary>
    /// Количество побед
    /// </summary>
    public int Wins { get; set; }

    /// <summary>
    /// Количество проигрышей
    /// </summary>
    public int Draw { get; set; }

    /// <summary>
    /// Количество игр, сыгранных вничью
    /// </summary>
    public int Lose { get; set; }

    /// <summary>
    /// Общее количество игр
    /// </summary>
    public int Games => Wins + Draw + Lose;
}