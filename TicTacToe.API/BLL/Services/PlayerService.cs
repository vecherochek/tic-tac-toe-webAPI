using TicTacToe.API.BLL.Models;
using TicTacToe.API.BLL.Services.Interfaces;
using TicTacToe.API.DAL.Repositories;

namespace TicTacToe.API.BLL.Services;

public class PlayerService : IPlayerService
{
    private readonly PlayerRepository _playerRepository;
    private readonly GameRepository _gameRepository;

    public PlayerService(PlayerRepository playerRepository, GameRepository gameRepository)
    {
        _playerRepository = playerRepository;
        _gameRepository = gameRepository;
    }

    public Player GetPlayerById(Guid id)
    {
        var player = _playerRepository.Get(id);
        if (player is null)
            throw new InvalidOperationException("Player with this id does not exists");
        return player;
    }

    public Player GetPlayerByName(string nickName)
    {
        var player = _playerRepository.GetPlayerByNickname(nickName);
        if (player is null)
            throw new InvalidOperationException("Player with this nickName does not exists");
        return player;
    }

    public IEnumerable<Player> GetAllPlayers()
    {
        return _playerRepository.GetPlayers();
    }

    public void UpdatePlayerOnline(Guid id, bool isOnline)
    {
        var player = GetPlayerById(id);

        if (player is null)
            throw new InvalidOperationException("Player with this id does not exists");

        player.IsOnline = isOnline;

        _playerRepository.Update(player);
        _playerRepository.Save();
    }

    public void DeletePlayer(Guid id)
    {
        var player = GetPlayerById(id);

        if (player is null)
            throw new InvalidOperationException("Player with this id does not exists");

        _playerRepository.Delete(id);
        _playerRepository.Save();
    }

    public PlayerScore GetPlayerScoreByNickname(string nickname)
    {
        var player = GetPlayerByName(nickname);

        if (player is null)
            throw new InvalidOperationException("Player with this id does not exists");

        return GetScore(player);
    }

    public PlayerScore GetPlayerScoreById(Guid id)
    {
        var player = GetPlayerById(id);

        if (player is null)
            throw new InvalidOperationException("Player with this id does not exists");
        return GetScore(player);
    }

    private PlayerScore GetScore(Player player)
    {
        var wins = _gameRepository.Games.Count(x => x.WinnerId == player.Id);
        var draws = _gameRepository.Games.Count(x => x.WinnerId == null);
        var loses = _gameRepository.Games.Count(x => x.WinnerId != player.Id);

        var score = new PlayerScore()
        {
            Wins = wins,
            Draw = draws,
            Lose = loses
        };

        return score;
    }
}