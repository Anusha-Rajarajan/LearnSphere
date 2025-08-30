using LearnSphere.API.DTOs;
using LearnSphere.API.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearnSphere.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProgressController : ControllerBase
{
    private readonly ProgressService _svc;
    public ProgressController(ProgressService svc) => _svc = svc;

    [HttpGet("{studentId:int}/{courseId:int}")]
    public async Task<IActionResult> Get(int studentId, int courseId)
        => Ok(await _svc.GetAsync(studentId, courseId));

    [HttpPut]
    [Authorize(Roles = "Mentor,Admin")]
    public async Task<IActionResult> Update([FromBody] ProgressDto dto)
        => (await _svc.UpsertAsync(dto)) ? NoContent() : BadRequest();
}
