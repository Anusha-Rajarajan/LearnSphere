using LearnSphere.API.Models;

namespace LearnSphere.API.Repositories;

public interface IProgressRepository : IGenericRepository<Progress>
{
    Task<Progress?> GetAsync(int studentId, int courseId);
}
