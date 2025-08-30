namespace LearnSphere.API.DTOs;

public class SessionDto
{
    public int SessionId { get; set; }
    public int CourseId { get; set; }
    public int MentorId { get; set; }
    public DateTime DateTime { get; set; }
    public string Status { get; set; } = "Scheduled";
}
