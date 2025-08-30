using LearnSphere.API.Data;
using LearnSphere.API.Models;

using Microsoft.EntityFrameworkCore;

namespace LearnSphere.API.Repositories;

public class ProgressRepository : GenericRepository<Progress>, IProgressRepository
{
    public ProgressRepository(LearnSphereDbContext db) : base(db) { }

    public Task<Progress?> GetAsync(int studentId, int courseId)
        => _set.FirstOrDefaultAsync(p => p.StudentId == studentId && p.CourseId == courseId);
}
