using LearnSphere.API.DTOs;
using LearnSphere.API.Models;
using LearnSphere.API.Repositories;


namespace LearnSphere.API.Services;

public class FeedbackService
{
    private readonly IFeedbackRepository _repo;
    public FeedbackService(IFeedbackRepository repo) => _repo = repo;

    public async Task<IEnumerable<FeedbackDto>> GetForMentorAsync(int mentorId)
        => (await _repo.GetForMentorAsync(mentorId))
            .Select(f => new FeedbackDto { FeedbackId = f.FeedbackId, StudentId = f.StudentId, MentorId = f.MentorId, Rating = f.Rating, Comment = f.Comment, Date = f.Date });

    public async Task<FeedbackDto> CreateAsync(FeedbackDto dto)
    {
        var f = new Feedback { StudentId = dto.StudentId, MentorId = dto.MentorId, Rating = dto.Rating, Comment = dto.Comment, Date = DateTime.UtcNow };
        await _repo.AddAsync(f); await _repo.SaveAsync();
        dto.FeedbackId = f.FeedbackId; dto.Date = f.Date; return dto;
    }
}
