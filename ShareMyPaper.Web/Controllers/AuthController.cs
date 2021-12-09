using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareMyPaper.Application.Dtos.Input;
using ShareMyPaper.Application.Dtos.Output;
using ShareMyPaper.Application.Input.Dtos;
using ShareMyPaper.Application.Interfaces.Services;
using ShareMyPaper.Application.Validators;

namespace ShareMyPaper.Web.Controllers;

[Route("api/[controller]")]
[ApiController]

public class AuthController : ControllerBase
{

    private readonly IAuthService _authService;
    private readonly ITokenService _tokenService;
    private readonly INotificationService _notificationService;

    public AuthController(
        ITokenService tokenService,
        IAuthService authService,
        INotificationService notificationService
        )
    {
        _tokenService = tokenService;
        _authService = authService;
        _notificationService = notificationService;
    }

    [HttpPost]
    [Route("student/register")]
    public async Task<IActionResult> RegisterStudent([FromForm] StudentInputDTO dto)
    {
        var validationResult = await new StudentDTOValidator().ValidateAsync(dto);
        if (!validationResult.IsValid) return BadRequest(validationResult);

        var identityResult = await _authService.RegisterStudent(dto);
        if (identityResult.Succeeded)
        {
            _ = _notificationService.NotifyModsAboutStudentSignup(dto.InstitutionId);
            return Ok(identityResult);
        }
        else
        {
            return BadRequest(identityResult);
        }
    }

    [HttpPost]
    [Authorize(Roles = "admin, institution moderator")]
    [Route("institution-moderator/register")]
    public async Task<IActionResult> RegisterInstitutionModerator(InstitutionModeratorInputDTO dto)
    {
        if(HttpContext.User.IsInRole("institution moderator")) 
        {
            dto.InstitutionId = new CurrentUser(HttpContext).InstitutionId;
        }
        var identityResult = await _authService.RegisterInstitutionModerator(dto);
        if (identityResult.Succeeded)
        {
            return Ok(identityResult);
        }
        else
        {
            return BadRequest(identityResult);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginInputDTO dto)
    {
        var user = await _authService.Login(dto.Email, dto.Password);
        if (user != null)
        {
            var token = _tokenService.BuildToken(user);
            var userOutput = new ApplicationUserOutputDTO()
            {
                Token = token,
                Role = user.Role,
                UserName = user.UserName
            };
            return Ok(userOutput);
        }
        return Unauthorized();
    }
}