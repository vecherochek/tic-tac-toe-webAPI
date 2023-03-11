using Microsoft.AspNetCore.Mvc;
using TicTacToe.API.BLL.Services;
using TicTacToe.API.Requests;
using TicTacToe.API.Responses;

namespace TicTacToe.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : Controller
{
    private AuthentificationService AuthenticationService { get; }
    private RegistrationService RegistrationService { get; }

    public AuthController(AuthentificationService authenticationService, RegistrationService registrationService)
    {
        AuthenticationService = authenticationService;
        RegistrationService = registrationService;
    }

    /// <summary>
    /// Player Authorization
    /// </summary>
    /// <param name="request">The player's nickname and password from the account</param>
    /// <returns></returns>
    [HttpPost("login")]
    public AuthResponse Authorization(AuthRequest request)
    {
        var player = AuthenticationService.GetPlayerByAuthData(request.Nickname, request.Password);
        return new AuthResponse(player);
    }

    /// <summary>
    /// Registration of a new player
    /// </summary>
    /// <param name="request">The player's nickname and password from the account</param>
    [HttpPost("register")]
    public void Registartion(RegistrationRequest request)
    {
        RegistrationService.CreateNewPlayer(request.Nickanme, request.Password);
    }
}