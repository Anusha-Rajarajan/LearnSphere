using Microsoft.EntityFrameworkCore;
using LearnSphere.API.Models;

namespace LearnSphere.API.Data;

public class LearnSphereDbContext : DbContext
{
    public LearnSphereDbContext(DbContextOptions<LearnSphereDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Session> Sessions => Set<Session>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();
    public DbSet<Progress> Progress => Set<Progress>();
    public DbSet<Feedback> Feedback => Set<Feedback>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<User>().HasIndex(u => u.Email).IsUnique();

        b.Entity<Course>()
            .HasOne(c => c.Mentor)
            .WithMany(u => u.CoursesAuthored)
            .HasForeignKey(c => c.MentorId)
            .OnDelete(DeleteBehavior.Restrict);

        b.Entity<Enrollment>()
            .HasOne(e => e.Course).WithMany(c => c.Enrollments).HasForeignKey(e => e.CourseId);
        b.Entity<Enrollment>()
            .HasOne(e => e.Student).WithMany(u => u.Enrollments).HasForeignKey(e => e.StudentId);

        b.Entity<Session>()
            .HasOne(s => s.Course).WithMany(c => c.Sessions).HasForeignKey(s => s.CourseId);
        b.Entity<Session>()
            .HasOne(s => s.Mentor).WithMany().HasForeignKey(s => s.MentorId).OnDelete(DeleteBehavior.Restrict);
    }
}
