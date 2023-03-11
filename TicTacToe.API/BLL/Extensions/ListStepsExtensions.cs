using TicTacToe.API.BLL.Enums;
using TicTacToe.API.BLL.Models;

namespace TicTacToe.API.BLL.Extensions;

public static class ListStepsExtensions
{
    internal static char[][] GetGameMatrix(this List<Step> steps)
    {
        var matrix = new char[3][];
        for (int i = 0; i < 3; i++)
            matrix[i] = new char[3];

        foreach (var step in steps)
        {
            var cell = step.Cell;
            matrix[cell.X][cell.Y] = step.Type == FigureType.Cross ? 'X' : 'O';
        }

        return matrix;
    }
}