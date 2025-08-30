using LearnSphere.API.Models;

namespace LearnSphere.API.Repositories;

public interface ISessionRepository : IGenericRepository<Session>
{
    Task<IEnumerable<Session>> GetByCourseAsync(int courseId);
}
