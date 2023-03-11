using TicTacToe.API.BLL.Models;

namespace TicTacToe.API.Requests.Game;

/// <summary>
/// Make Step Request
/// </summary>
/// <param name="Step">Information about step</param>
public record MakeStepRequest(Step Step);