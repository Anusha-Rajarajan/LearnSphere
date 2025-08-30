using LearnSphere.API.Data;
using LearnSphere.API.Models;

using Microsoft.EntityFrameworkCore;

namespace LearnSphere.API.Repositories;

public class FeedbackRepository : GenericRepository<Feedback>, IFeedbackRepository
{
    public FeedbackRepository(LearnSphereDbContext db) : base(db) { }
    public async Task<IEnumerable<Feedback>> GetForMentorAsync(int mentorId)
        => await _set.Where(f => f.MentorId == mentorId).ToListAsync();
}
