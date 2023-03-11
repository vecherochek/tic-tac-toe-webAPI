using Microsoft.AspNetCore.Mvc;
using TicTacToe.API.BLL.Services;
using TicTacToe.API.Requests.Auth;
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

    [HttpPost("login")]
    public AuthResponse Authorization(AuthRequest request)
    {
        var player = AuthenticationService.GetPlayerByAuthData(request.Nickname, request.Password);
        return new AuthResponse(player);
    }

    [HttpPost("register")]
    public void Registartion(RegistrationRequest request)
    {
       RegistrationService.CreateNewPlayer(request.Nickanme, request.Password);
    }
}