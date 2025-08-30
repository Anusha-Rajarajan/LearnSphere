using LearnSphere.API.Data;
using LearnSphere.API.Models;


namespace LearnSphere.API.Repositories;

public class CourseRepository : GenericRepository<Course>, ICourseRepository
{
    public CourseRepository(LearnSphereDbContext db) : base(db) { }
}
