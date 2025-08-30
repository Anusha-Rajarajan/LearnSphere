namespace LearnSphere.API.DTOs;

public class AuthRequestDto
{
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
    public string? Name { get; set; } // for register
    public string? Role { get; set; } // optional: Admin/Mentor/Student
}
