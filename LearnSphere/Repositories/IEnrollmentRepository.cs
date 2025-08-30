using LearnSphere.API.Models;

namespace LearnSphere.API.Repositories;

public interface IEnrollmentRepository : IGenericRepository<Enrollment>
{
    Task<bool> ExistsAsync(int studentId, int courseId);
    Task<IEnumerable<Enrollment>> GetByStudentAsync(int studentId);
}
