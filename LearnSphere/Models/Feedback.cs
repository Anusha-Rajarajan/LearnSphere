namespace LearnSphere.API.Models;

public class Feedback
{
    public int FeedbackId { get; set; }
    public int StudentId { get; set; }
    public int MentorId { get; set; }
    public int Rating { get; set; } // 1-5
    public string Comment { get; set; } = "";
    public DateTime Date { get; set; } = DateTime.UtcNow;
}
