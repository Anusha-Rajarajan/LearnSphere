using LearnSphere.API.Models;

namespace LearnSphere.API.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
}
