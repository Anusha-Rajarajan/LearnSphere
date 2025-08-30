using LearnSphere.API.DTOs;
using LearnSphere.API.Models;
using LearnSphere.API.Repositories;


namespace LearnSphere.API.Services;

public class CourseService
{
    private readonly ICourseRepository _repo;
    public CourseService(ICourseRepository repo) => _repo = repo;

    public async Task<IEnumerable<CourseDto>> GetAllAsync()
        => (await _repo.GetAllAsync())
            .Select(c => new CourseDto { CourseId = c.CourseId, Title = c.Title, Description = c.Description, MentorId = c.MentorId, Duration = c.Duration, Syllabus = c.Syllabus });

    public async Task<CourseDto?> GetByIdAsync(int id)
    {
        var c = await _repo.GetByIdAsync(id);
        return c is null ? null : new CourseDto { CourseId = c.CourseId, Title = c.Title, Description = c.Description, MentorId = c.MentorId, Duration = c.Duration, Syllabus = c.Syllabus };
    }

    public async Task<CourseDto> CreateAsync(CourseDto dto)
    {
        var c = new Course { Title = dto.Title, Description = dto.Description, MentorId = dto.MentorId, Duration = dto.Duration, Syllabus = dto.Syllabus };
        await _repo.AddAsync(c); await _repo.SaveAsync();
        dto.CourseId = c.CourseId; return dto;
    }

    public async Task<bool> UpdateAsync(int id, CourseDto dto)
    {
        var c = await _repo.GetByIdAsync(id); if (c is null) return false;
        c.Title = dto.Title; c.Description = dto.Description; c.MentorId = dto.MentorId; c.Duration = dto.Duration; c.Syllabus = dto.Syllabus;
        _repo.Update(c); await _repo.SaveAsync(); return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var c = await _repo.GetByIdAsync(id); if (c is null) return false;
        _repo.Delete(c); await _repo.SaveAsync(); return true;
    }
}
