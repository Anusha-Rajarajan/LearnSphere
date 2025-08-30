using LearnSphere.API.DTOs;
using LearnSphere.API.Models;
using LearnSphere.API.Repositories;

using System.Security.Claims;

namespace LearnSphere.API.Services;

public class EnrollmentService
{
    private readonly IEnrollmentRepository _repo;

    public EnrollmentService(IEnrollmentRepository repo) => _repo = repo;

    public async Task<EnrollmentDto> EnrollAsync(EnrollmentDto dto)
    {
        var exists = await _repo.ExistsAsync(dto.StudentId, dto.CourseId);
        if (exists) return dto; // idempotent

        var e = new Enrollment { CourseId = dto.CourseId, StudentId = dto.StudentId };
        await _repo.AddAsync(e); await _repo.SaveAsync();
        dto.EnrollmentId = e.EnrollmentId; dto.EnrollDate = e.EnrollDate;
        return dto;
    }

    public async Task<IEnumerable<EnrollmentDto>> GetForCurrentUserAsync(ClaimsPrincipal user)
    {
        var sid = int.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var items = await _repo.GetByStudentAsync(sid);
        return items.Select(e => new EnrollmentDto { EnrollmentId = e.EnrollmentId, CourseId = e.CourseId, StudentId = e.StudentId, EnrollDate = e.EnrollDate });
    }
}
