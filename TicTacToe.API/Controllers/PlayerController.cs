using Microsoft.AspNetCore.Mvc;
using TicTacToe.API.BLL.Services;
using TicTacToe.API.Requests;
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

    /// <summary>
    /// Getting information about a player by Id
    /// </summary>
    /// <param name="playerId">Player Id</param>
    /// <returns></returns>
    [HttpGet("{playerId}")]
    public GetPlayerResponse Get(Guid playerId)
    {
        var player = _playerService.GetPlayerById(playerId);
        return new GetPlayerResponse(player);
    }

    /// <summary>
    /// Getting information about a player by Nickname
    /// </summary>
    /// <param name="nickName">Player nickname</param>
    /// <returns></returns>
    [HttpGet("[action]/{nickName}")]
    public GetPlayerResponse Get(string nickName)
    {
        var player = _playerService.GetPlayerByName(nickName);
        return new GetPlayerResponse(player);
    }

    /// <summary>
    /// Getting information about the player's total account by Nickname
    /// </summary>
    /// <param name="nickName">Player nickname</param>
    /// <returns></returns>
    [HttpGet("score/{nickName}")]
    public GetPlayerScoreResponse GetPlayerScore(string nickName)
    {
        var score = _playerService.GetPlayerScoreByNickname(nickName);
        return new GetPlayerScoreResponse(score);
    }

    /// <summary>
    /// Getting information about the player's total account by Id
    /// </summary>
    /// <param name="playerId">Player Id</param>
    /// <returns></returns>
    [HttpGet("[action]/score/{playerid}")]
    public GetPlayerScoreResponse GetPlayerScore(Guid playerId)
    {
        var score = _playerService.GetPlayerScoreById(playerId);
        return new GetPlayerScoreResponse(score);
    }

    /// <summary>
    /// Getting all the players
    /// </summary>
    /// <returns></returns>
    [HttpGet("all-players-list")]
    public GetAllPlayersListResponse GetAllPlayers()
    {
        var players = _playerService.GetAllPlayers();
        return new GetAllPlayersListResponse(players);
    }

    /// <summary>
    /// Deleting a player
    /// </summary>
    /// <param name="playerId"></param>
    [HttpDelete("{playerId}")]
    public void DeletePlayer(Guid playerId)
    {
        _playerService.DeletePlayer(playerId);
    }

    /// <summary>
    /// Changing the online player
    /// </summary>
    /// <param name="playerId"></param>
    /// <param name="request"></param>
    [HttpPut("{playerId}/online/")]
    public void UpdatePlayerOnline(Guid playerId, UpdatePlayerOnlineRequest request)
    {
        _playerService.UpdatePlayerOnline(playerId, request.IsOnline);
    }
}