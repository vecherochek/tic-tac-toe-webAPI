using TicTacToe.API.BLL.Models;
using TicTacToe.API.BLL.Services.Interfaces;
using TicTacToe.API.DAL.Repositories;

namespace TicTacToe.API.BLL.Services;

/// <inheritdoc />
public class RegistrationService : IRegistrationService
{
    private readonly PlayerRepository _playerRepository;

    public RegistrationService(PlayerRepository repository)
    {
        _playerRepository = repository;
    }

    /// <inheritdoc />
    public void CreateNewPlayer(string nickname, byte[] password)
    {
        var player = _playerRepository.GetPlayerByNickname(nickname);

        if (player != null)
            throw new InvalidOperationException("The nickname already exists");

        _playerRepository.Create(Player.CreateFromNicknameAndPass(nickname, password));
        _playerRepository.Save();
    }
}