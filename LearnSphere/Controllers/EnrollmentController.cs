using LearnSphere.API.DTOs;
using LearnSphere.API.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearnSphere.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Student,Admin")]
public class EnrollmentsController : ControllerBase
{
    private readonly EnrollmentService _svc;
    public EnrollmentsController(EnrollmentService svc) => _svc = svc;

    [HttpPost]
    public async Task<IActionResult> Enroll([FromBody] EnrollmentDto dto)
        => Ok(await _svc.EnrollAsync(dto));

    [HttpGet("my")]
    public async Task<IActionResult> MyEnrollments()
        => Ok(await _svc.GetForCurrentUserAsync(User));
}
