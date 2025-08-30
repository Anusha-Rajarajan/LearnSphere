using LearnSphere.API.DTOs;
using LearnSphere.API.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearnSphere.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SessionsController : ControllerBase
{
    private readonly SessionService _svc;
    public SessionsController(SessionService svc) => _svc = svc;

    [HttpGet("{courseId:int}")]
    public async Task<IActionResult> ByCourse(int courseId) => Ok(await _svc.GetByCourseAsync(courseId));

    [HttpPost]
    [Authorize(Roles = "Mentor,Admin")]
    public async Task<IActionResult> Create([FromBody] SessionDto dto) => Ok(await _svc.CreateAsync(dto));

    [HttpPut("{id:int}")]
    [Authorize(Roles = "Mentor,Admin")]
    public async Task<IActionResult> Update(int id, [FromBody] SessionDto dto)
        => (await _svc.UpdateAsync(id, dto)) ? NoContent() : NotFound();

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Mentor,Admin")]
    public async Task<IActionResult> Delete(int id)
        => (await _svc.DeleteAsync(id)) ? NoContent() : NotFound();
}
