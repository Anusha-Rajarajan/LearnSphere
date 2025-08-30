using LearnSphere.API.DTOs;
using LearnSphere.API.Helpers;
using LearnSphere.API.Models;
using LearnSphere.API.Repositories;


namespace LearnSphere.API.Services;

public class AuthService
{
    private readonly IUserRepository _users;
    private readonly JwtHelper _jwt;
    private readonly PasswordHasher _hasher;

    public AuthService(IUserRepository users, JwtHelper jwt, PasswordHasher hasher)
    {
        _users = users; _jwt = jwt; _hasher = hasher;
    }

    public async Task<AuthResponseDto> RegisterAsync(AuthRequestDto req)
    {
        var existing = await _users.GetByEmailAsync(req.Email);
        if (existing is not null)
            return new AuthResponseDto { Success = false, Message = "Email already registered" };

        var user = new User
        {
            Name = req.Name ?? req.Email.Split('@')[0],
            Email = req.Email,
            PasswordHash = _hasher.Hash(req.Password),
            Role = string.IsNullOrWhiteSpace(req.Role) ? "Student" : req.Role!
        };

        await _users.AddAsync(user);
        await _users.SaveAsync();

        var token = _jwt.GenerateToken(user.UserId, user.Email, user.Role);
        return new AuthResponseDto
        {
            Success = true,
            Message = "Registered",
            Token = token,
            User = new UserDto { UserId = user.UserId, Name = user.Name, Email = user.Email, Role = user.Role }
        };
    }

    public async Task<AuthResponseDto> LoginAsync(string email, string password)
    {
        var user = await _users.GetByEmailAsync(email);
        if (user is null || !_hasher.Verify(password, user.PasswordHash))
            return new AuthResponseDto { Success = false, Message = "Invalid credentials" };

        var token = _jwt.GenerateToken(user.UserId, user.Email, user.Role);
        return new AuthResponseDto
        {
            Success = true,
            Message = "OK",
            Token = token,
            User = new UserDto { UserId = user.UserId, Name = user.Name, Email = user.Email, Role = user.Role }
        };
    }
}
