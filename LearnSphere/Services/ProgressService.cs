using LearnSphere.API.DTOs;
using LearnSphere.API.Models;
using LearnSphere.API.Repositories;


namespace LearnSphere.API.Services;

public class ProgressService
{
    private readonly IProgressRepository _repo;
    public ProgressService(IProgressRepository repo) => _repo = repo;

    public async Task<ProgressDto?> GetAsync(int studentId, int courseId)
    {
        var p = await _repo.GetAsync(studentId, courseId);
        return p is null ? null : new ProgressDto { ProgressId = p.ProgressId, StudentId = p.StudentId, CourseId = p.CourseId, Milestone = p.Milestone, CompletionPercent = p.CompletionPercent };
    }

    public async Task<bool> UpsertAsync(ProgressDto dto)
    {
        var p = await _repo.GetAsync(dto.StudentId, dto.CourseId);
        if (p is null)
        {
            p = new Progress { StudentId = dto.StudentId, CourseId = dto.CourseId, Milestone = dto.Milestone, CompletionPercent = dto.CompletionPercent };
            await _repo.AddAsync(p);
        }
        else
        {
            p.Milestone = dto.Milestone; p.CompletionPercent = dto.CompletionPercent;
            _repo.Update(p);
        }
        await _repo.SaveAsync(); return true;
    }
}
