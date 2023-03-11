namespace TicTacToe.API.BLL.Models;

public class PlayerScore
{
    public int Wins { get; set; }
    
    public int Draw { get; set; }
    
    public int Lose { get; set; }

    public int Games => Wins + Draw + Lose;
}