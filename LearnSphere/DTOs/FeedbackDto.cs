namespace LearnSphere.API.DTOs;

public class FeedbackDto
{
    public int FeedbackId { get; set; }
    public int StudentId { get; set; }
    public int MentorId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = "";
    public DateTime Date { get; set; }
}
