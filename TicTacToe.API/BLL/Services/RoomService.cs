using TicTacToe.API.BLL.Models;
using TicTacToe.API.BLL.Services.Interfaces;
using TicTacToe.API.DAL.Repositories;

namespace TicTacToe.API.BLL.Services;

public class RoomService : IRoomService
{
    private readonly RoomRepository _roomRepository;
    private readonly GameRepository _gameRepository;
    private readonly PlayerRepository _playerRepository;

    public RoomService(RoomRepository roomRepository, GameRepository gameRepository, PlayerRepository playerRepository)
    {
        _roomRepository = roomRepository;
        _gameRepository = gameRepository;
        _playerRepository = playerRepository;
    }

    public Room GetRoom(Guid roomId)
    {
        var game = _roomRepository.Get(roomId);
        if (game is null)
            throw new InvalidOperationException("Room with this id does not exists");
        return game;
    }

    public void LeaveRoom(Guid playerId, Guid roomId)
    {
        var player = _playerRepository.Get(playerId);
        if (player is null)
            throw new InvalidOperationException("Player with this id does not exists");
        
        var room = GetRoom(roomId);
        if (room is null)
            throw new InvalidOperationException("Room with this id does not exists");
        
        room.Players.Remove(player);
        _roomRepository.Update(room);
        _roomRepository.Save();
    }

    public Guid CreateRoom(Guid playerId)
    {
        var player = _playerRepository.Get(playerId);
        if (player is null)
            throw new InvalidOperationException("Player with this id does not exists");
        
        var room = new Room
        {
            Id = Guid.NewGuid(),
            Score = new RoomScore
            {
                XWins = 0,
                OWins = 0
            },
            Players = new List<Player>(){player}
        };
        
        _roomRepository.Create(room);
        _roomRepository.Save();
        return room.Id;
    }

    public void AddPlayerToRoom(Guid playerId, Guid roomId)
    {
        var player = _playerRepository.Get(playerId);
        if (player is null)
            throw new InvalidOperationException("Player with this id does not exists");
        
        var room = GetRoom(roomId);
        if (room is null)
            throw new InvalidOperationException("Room with this id does not exists");
        
        if (room.Players.Count >= 2)
            throw new InvalidOperationException("The room is full");
        
        room.Players.Add(player);
        
        _roomRepository.Update(room);
        _roomRepository.Save();
    }

    public Guid StartGame(Guid roomId)
    {
        var room = GetRoom(roomId);
        
        if (room is null)
            throw new InvalidOperationException("Room with this id does not exists");
        
        if (room.Games.Last().IsFinished is false)
            throw new InvalidOperationException("The game in the room is not over yet");
        
        if (room.Players.Count != 2)
             throw new InvalidOperationException("Not enough players to start the game");

        var randomId = new Random().Next(0, 2);
        var game =  new Game
        {
            Id = Guid.NewGuid(),
            PlayerOId = room.Players[randomId].Id,
            PlayerXId = room.Players[(randomId + 1) % 2].Id,
            IsFinished = false,
            Steps = new List<Step>()
        };
        
        _gameRepository.Create(game);
        _gameRepository.Save();
        
        return room.Id;
    }
}