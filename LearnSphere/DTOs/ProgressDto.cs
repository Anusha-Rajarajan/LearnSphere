namespace LearnSphere.API.DTOs;

public class ProgressDto
{
    public int ProgressId { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public string Milestone { get; set; } = "";
    public int CompletionPercent { get; set; }
}
