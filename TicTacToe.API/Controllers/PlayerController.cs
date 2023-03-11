using Microsoft.AspNetCore.Mvc;
using TicTacToe.API.BLL.Services;
using TicTacToe.API.Requests.Player;
using TicTacToe.API.Responses;

namespace TicTacToe.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController : Controller
{
    private readonly PlayerService _playerService;

    public PlayerController(PlayerService playerService)
    {
        _playerService = playerService;
    }

    [HttpGet("{playerId}")]
    public GetPlayerResponse Get(Guid playerId)
    {
        var player = _playerService.GetPlayerById(playerId);
        return new GetPlayerResponse(player);
    }

    [HttpGet("{nickName}")]
    public GetPlayerResponse Get(string nickName)
    {
        var player = _playerService.GetPlayerByName(nickName);
        return new GetPlayerResponse(player);
    }

    [HttpGet("score/{nickname}")]
    public GetPlayerScoreResponse GetPlayerScore(string nickName)
    {
        var score = _playerService.GetPlayerScoreByNickname(nickName);
        return new GetPlayerScoreResponse(score);
    }

    [HttpGet("score/{playerid}")]
    public GetPlayerScoreResponse GetPlayerScore(Guid playerId)
    {
        var score = _playerService.GetPlayerScoreById(playerId);
        return new GetPlayerScoreResponse(score);
    }

    [HttpGet("all-players-list")]
    public GetAllPlayersListResponse GetAllPlayers()
    {
        var players = _playerService.GetAllPlayers();
        return new GetAllPlayersListResponse(players);
    }

    [HttpDelete("{playerId}")]
    public void DeletePlayer(Guid playerId)
    {
        _playerService.DeletePlayer(playerId);
    }

    [HttpPut("{playerId}/online/")]
    public void UpdatePlayerOnline(Guid playerId, UpdatePlayerOnlineRequest request)
    {
        _playerService.UpdatePlayerOnline(playerId, request.IsOnline);
    }
}