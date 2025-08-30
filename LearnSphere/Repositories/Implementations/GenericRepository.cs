using LearnSphere.API.Data;

using Microsoft.EntityFrameworkCore;

namespace LearnSphere.API.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly LearnSphereDbContext _db;
    protected readonly DbSet<T> _set;
    public GenericRepository(LearnSphereDbContext db) { _db = db; _set = db.Set<T>(); }

    public async Task<IEnumerable<T>> GetAllAsync() => await _set.ToListAsync();
    public async Task<T?> GetByIdAsync(int id) => await _set.FindAsync(id);
    public async Task AddAsync(T entity) { await _set.AddAsync(entity); }
    public void Update(T entity) { _set.Update(entity); }
    public void Delete(T entity) { _set.Remove(entity); }
    public Task<int> SaveAsync() => _db.SaveChangesAsync();
}
