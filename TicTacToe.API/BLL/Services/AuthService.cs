using TicTacToe.API.BLL.Models;
using TicTacToe.API.BLL.Services.Interfaces;
using TicTacToe.API.DAL.Repositories;

namespace TicTacToe.API.BLL.Services;

public class AuthentificationService : IAuthentificationService
{
    private readonly PlayerRepository _playerRepository;

    public AuthentificationService(PlayerRepository playerRepository)
    {
        this._playerRepository = playerRepository;
    }

    public bool IsExists(string nickname)
    {
        return _playerRepository.GetPlayerByNickname(nickname) is not null;
    }

    public Player GetPlayerByAuthData(string nickname, byte[] password)
    {
        var player = _playerRepository.GetPlayerByNickname(nickname);

        if (player is null)
            throw new InvalidOperationException("Invalid nickname");
        if (player.SaltedPassword != password)
            throw new InvalidOperationException("Invalid password");

        return player;
    }
}