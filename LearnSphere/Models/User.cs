

namespace LearnSphere.API.Models;

public class User
{
    public int UserId { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string PasswordHash { get; set; } = "";
    public string Role { get; set; } = "Student"; // Admin | Mentor | Student

    public List<Course> CoursesAuthored { get; set; } = new();
    public List<Enrollment> Enrollments { get; set; } = new();
    public List<Feedback> FeedbackGiven { get; set; } = new();
}
