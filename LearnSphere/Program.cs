using LearnSphere.API.Data;
using LearnSphere.API.Helpers;
using LearnSphere.API.Middleware;
using LearnSphere.API.Repositories;
using LearnSphere.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var cfg = builder.Configuration;

// DbContext
builder.Services.AddDbContext<LearnSphereDbContext>(opt =>
    opt.UseSqlServer(cfg.GetConnectionString("DefaultConnection")));

// Repos
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
builder.Services.AddScoped<IProgressRepository, ProgressRepository>();
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();

// Services
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<SessionService>();
builder.Services.AddScoped<EnrollmentService>();
builder.Services.AddScoped<ProgressService>();
builder.Services.AddScoped<FeedbackService>();

// Helpers
builder.Services.AddSingleton<JwtHelper>();
builder.Services.AddSingleton<PasswordHasher>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Auth
builder.Services.AddJwtAuth(cfg);
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseMiddleware<LearnSphere.API.Middleware.ErrorHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
