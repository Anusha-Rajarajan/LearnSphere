
namespace LearnSphere.API.Models;

public class Course
{
    public int CourseId { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public int MentorId { get; set; }
    public User? Mentor { get; set; }
    public int Duration { get; set; } // hours
    public string? Syllabus { get; set; }

    public List<Session> Sessions { get; set; } = new();
    public List<Enrollment> Enrollments { get; set; } = new();
}
