using Microsoft.AspNetCore.Mvc;
using TicTacToe.API.BLL.Services;
using TicTacToe.API.Requests.Game;
using TicTacToe.API.Responses;

namespace TicTacToe.API.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : Controller
{
    private readonly GameService _gameService;

    public GameController(GameService gameService)
    {
        _gameService = gameService;
    }

    /// <summary>
    /// Getting information about the game by Id
    /// </summary>
    /// <param name="gameId">Game Id</param>
    /// <returns></returns>
    [HttpGet("{gameId}")]
    public GetGameResponse Get(Guid gameId)
    {
        var game = _gameService.GetGame(gameId);
        return new GetGameResponse(game);
    }

    /// <summary>
    /// Make a move
    /// </summary>
    /// <param name="gameId">Id of the game in which you need to make a step</param>
    /// <param name="request">Step Information</param>
    [HttpPut("{gameId}/make-step")]
    public void MakeStep(Guid gameId, MakeStepRequest request)
    {
        _gameService.MakeStep(gameId, request.Step);
    }
}