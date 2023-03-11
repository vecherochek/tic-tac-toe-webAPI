namespace TicTacToe.API.BLL.Models;

/// <summary>
/// Клетка игрового поля
/// </summary>
/// <param name="X">x-координата</param>
/// <param name="Y">y-координата</param>
public record Cell(int X, int Y);