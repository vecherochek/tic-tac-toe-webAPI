using TicTacToe.API.BLL.Enums;
using TicTacToe.API.BLL.Extensions;
using TicTacToe.API.BLL.Models;
using TicTacToe.API.BLL.Services.Interfaces;
using TicTacToe.API.DAL.Repositories;

namespace TicTacToe.API.BLL.Services;

public class GameService : IGameService
{
    private readonly GameRepository _gameRepository;

    public GameService(GameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public Game? GetGame(Guid gameId)
    {
        var game = _gameRepository.Get(gameId);
        if (game is null)
            throw new InvalidOperationException("Room with this id does not exists");
        return _gameRepository.Get(gameId);
    }

    public bool MakeStep(Guid gameId, Step step)
    {
        var game = _gameRepository.Get(gameId);

        if (game is null)
            throw new InvalidOperationException("Room with this id does not exists");
        
        if (game.IsFinished)
            throw new InvalidOperationException("Can't make a move, the game is already over");
        
        if (game.Steps.Last().Type == step.Type)
            throw new InvalidOperationException("Wait for the previous player's turn");

        foreach (var s in game.Steps)
        {
            if (s.Cell == step.Cell)
                throw new InvalidOperationException("Сannot make a move in this cell");
        }
        
        game.Steps?.Add(step);
        var isFinished = IsGameFinished(game, step.Type);
        if (isFinished)
        {
            game.IsFinished = true;
            
            game.WinnerId = step.OwnerId;
        }

        if (game.Steps.Count == 9)
        {
            game.IsFinished = true;
            game.WinnerId = null;
        }
        
        _gameRepository.Update(game);
        _gameRepository.Save();

        return true;
    }

    private bool IsGameFinished(Game game, FigureType stepType)
    {
        var matrix = game.Steps?.GetGameMatrix();

        if (CheckWin(matrix, stepType))
            return true;
        return false;
    }
    private bool CheckWin(char[][] board, FigureType type)
    {
        var symbol = type == FigureType.Cross ? 'X' : 'O';
        
        for (int i = 0; i < 3; i++)
        {
            if (board[i][0] == symbol && board[i][1] == symbol && board[i][2] == symbol)
                return true;
        }

        for (int j = 0; j < 3; j++)
        {
            if (board[0][j] == symbol && board[1][j] == symbol && board[2][j] == symbol)
                return true;
        }

        if (board[0][0] == symbol && board[1][1] == symbol && board[2][2] == symbol)
            return true;

        if (board[0][2] == symbol && board[1][1] == symbol && board[2][0] == symbol)
            return true;

        return false;
    }
    
}