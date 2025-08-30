using LearnSphere.API.Data;
using LearnSphere.API.Models;

using Microsoft.EntityFrameworkCore;

namespace LearnSphere.API.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(LearnSphereDbContext db) : base(db) { }
    public Task<User?> GetByEmailAsync(string email) => _set.FirstOrDefaultAsync(u => u.Email == email);
}
