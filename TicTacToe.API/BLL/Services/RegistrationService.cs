using TicTacToe.API.BLL.Models;
using TicTacToe.API.BLL.Services.Interfaces;
using TicTacToe.API.DAL.Repositories;

namespace TicTacToe.API.BLL.Services;

public class RegistrationService : IRegistrationService
{
    private readonly PlayerRepository _playerRepository;

    public RegistrationService(PlayerRepository repository)
    {
        _playerRepository = repository;
    }

    public void CreateNewPlayer(string nickname, byte[] password)
    {
        var player = _playerRepository.GetPlayerByNickname(nickname);

        if (player != null)
            throw new InvalidOperationException("The nickname already exists");
        
        player = new Player
        {
            Id = Guid.NewGuid(),
            Nickname = nickname,
            SaltedPassword = password
        };
        
        _playerRepository.Create(player);
        _playerRepository.Save();
    }
}