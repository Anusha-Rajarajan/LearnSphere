using LearnSphere.API.Data;
using LearnSphere.API.Models;

using Microsoft.EntityFrameworkCore;

namespace LearnSphere.API.Repositories;

public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
{
    public EnrollmentRepository(LearnSphereDbContext db) : base(db) { }

    public Task<bool> ExistsAsync(int studentId, int courseId)
        => _set.AnyAsync(e => e.StudentId == studentId && e.CourseId == courseId);

    public async Task<IEnumerable<Enrollment>> GetByStudentAsync(int studentId)
        => await _set.Where(e => e.StudentId == studentId).ToListAsync();
}
