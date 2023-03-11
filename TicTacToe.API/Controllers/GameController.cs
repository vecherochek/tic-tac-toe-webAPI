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

    [HttpGet("{gameId}")]
    public GetGameResponse Get(Guid gameId)
    {
        var game = _gameService.GetGame(gameId);
        return new GetGameResponse(game);
    }

    [HttpPut("{gameId}/make-step")]
    public void MakeStep(Guid gameId, MakeStepRequest request)
    {
        _gameService.MakeStep(gameId, request.Step);
    }
}