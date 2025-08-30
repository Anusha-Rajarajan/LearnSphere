using LearnSphere.API.DTOs;
using LearnSphere.API.Repositories;


namespace LearnSphere.API.Services;

public class UserService
{
    private readonly IUserRepository _repo;
    public UserService(IUserRepository repo) => _repo = repo;

    public async Task<IEnumerable<UserDto>> GetAllAsync()
        => (await _repo.GetAllAsync())
            .Select(u => new UserDto { UserId = u.UserId, Name = u.Name, Email = u.Email, Role = u.Role });

    public async Task<UserDto?> GetByIdAsync(int id)
    {
        var u = await _repo.GetByIdAsync(id);
        return u is null ? null : new UserDto { UserId = u.UserId, Name = u.Name, Email = u.Email, Role = u.Role };
    }

    public async Task<bool> UpdateAsync(int id, UserDto dto)
    {
        var u = await _repo.GetByIdAsync(id);
        if (u is null) return false;
        u.Name = dto.Name; u.Email = dto.Email; u.Role = dto.Role;
        _repo.Update(u);
        await _repo.SaveAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var u = await _repo.GetByIdAsync(id);
        if (u is null) return false;
        _repo.Delete(u);
        await _repo.SaveAsync();
        return true;
    }
}
