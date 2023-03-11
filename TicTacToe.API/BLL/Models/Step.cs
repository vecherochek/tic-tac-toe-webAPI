using TicTacToe.API.BLL.Enums;

namespace TicTacToe.API.BLL.Models;

public class Step
{
    public Guid OwnerId { get; set; }
    public FigureType Type { get; set; }
    public Cell Cell { get; set; }
}