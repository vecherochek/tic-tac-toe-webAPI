using Microsoft.AspNetCore.Mvc;
using TicTacToe.API.BLL.Models;
using TicTacToe.API.BLL.Services;
using TicTacToe.API.DAL.Repositories;
using TicTacToe.API.Requests.Room;
using TicTacToe.API.Responses;

namespace TicTacToe.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RoomController : Controller
{
    public RoomService RoomService { get; }

    public RoomController(RoomService roomService)
    {
        RoomService = roomService;
    }

    [HttpGet("{roomId}")]
    public GetRoomResponse Get(Guid roomId)
    {
        var room = RoomService.GetRoom(roomId);
        return new GetRoomResponse(room);
    }

    [HttpPost("create-room")]
    public CreateRoomResponse CreateRoom(CreateRoomRequest request)
    {
        var room = RoomService.CreateRoom(request.playerId);
        return new CreateRoomResponse(room);
    }

    [HttpPut("{roomId}/add-to-room")]
    public void AddPlayerToRoom(Guid roomId, AddPlayerToRoomRequest request)
    {
        RoomService.AddPlayerToRoom(roomId, request.playerId);
    }

    [HttpPut("{roomId}/leave-room")]
    public void LeaveRoom(Guid roomId, AddPlayerToRoomRequest request)
    {
        RoomService.LeaveRoom(roomId, request.playerId);
    }

    [HttpPost("{roomId}/create-game")]
    public CreateGameResponse CraeteGame(Guid roomId)
    {
        var gameId = RoomService.StartGame(roomId);
        return new CreateGameResponse(gameId);
    }
}