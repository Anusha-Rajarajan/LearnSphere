namespace LearnSphere.API.DTOs;

public class EnrollmentDto
{
    public int EnrollmentId { get; set; }
    public int CourseId { get; set; }
    public int StudentId { get; set; }
    public DateTime EnrollDate { get; set; }
}
