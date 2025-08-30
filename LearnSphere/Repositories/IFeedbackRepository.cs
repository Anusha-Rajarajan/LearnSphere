using LearnSphere.API.Models;

namespace LearnSphere.API.Repositories;

public interface IFeedbackRepository : IGenericRepository<Feedback>
{
    Task<IEnumerable<Feedback>> GetForMentorAsync(int mentorId);
}
