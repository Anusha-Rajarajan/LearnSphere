namespace LearnSphere.API.DTOs;

public class CourseDto
{
    public int CourseId { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public int MentorId { get; set; }
    public int Duration { get; set; }
    public string? Syllabus { get; set; }
}
