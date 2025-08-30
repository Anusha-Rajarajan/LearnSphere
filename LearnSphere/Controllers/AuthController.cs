using LearnSphere.API.DTOs;
using LearnSphere.API.Services;

using Microsoft.AspNetCore.Mvc;

namespace LearnSphere.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _auth;
    public AuthController(AuthService auth) => _auth = auth;

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] AuthRequestDto req)
    {
        var result = await _auth.RegisterAsync(req);
        if (!result.Success) return BadRequest(new { result.Message });
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AuthRequestDto req)
    {
        var result = await _auth.LoginAsync(req.Email, req.Password);
        if (!result.Success) return Unauthorized(new { result.Message });
        return Ok(result);
    }
}
