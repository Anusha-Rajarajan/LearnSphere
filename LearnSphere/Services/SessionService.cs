using LearnSphere.API.DTOs;
using LearnSphere.API.Models;
using LearnSphere.API.Repositories;


namespace LearnSphere.API.Services;

public class SessionService
{
    private readonly ISessionRepository _repo;
    public SessionService(ISessionRepository repo) => _repo = repo;

    public async Task<IEnumerable<SessionDto>> GetByCourseAsync(int courseId)
    {
        return (await _repo.GetByCourseAsync(courseId))
            .Select(s => new SessionDto
            {
                SessionId = s.SessionId,
                CourseId = s.CourseId,
                MentorId = s.MentorId,
                DateTime = s.DateTime,
                Status = s.Status
            });
    }


    public async Task<SessionDto> CreateAsync(SessionDto dto)
    {
        var s = new Session { CourseId = dto.CourseId, MentorId = dto.MentorId, DateTime = dto.DateTime, Status = dto.Status };
        await _repo.AddAsync(s); await _repo.SaveAsync();
        dto.SessionId = s.SessionId; return dto;
    }

    public async Task<bool> UpdateAsync(int id, SessionDto dto)
    {
        var s = await _repo.GetByIdAsync(id); if (s is null) return false;
        s.DateTime = dto.DateTime; s.Status = dto.Status;
        _repo.Update(s); await _repo.SaveAsync(); return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var s = await _repo.GetByIdAsync(id); if (s is null) return false;
        _repo.Delete(s); await _repo.SaveAsync(); return true;
    }
}
