using LearnSphere.API.Data;
using LearnSphere.API.Models;

using Microsoft.EntityFrameworkCore;

namespace LearnSphere.API.Repositories;

public class SessionRepository : GenericRepository<Session>, ISessionRepository
{
    public SessionRepository(LearnSphereDbContext db) : base(db) { }
    public async Task<IEnumerable<Session>> GetByCourseAsync(int courseId)
        => await _set.Where(s => s.CourseId == courseId).ToListAsync();
}
