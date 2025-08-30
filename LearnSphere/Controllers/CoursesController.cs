using LearnSphere.API.DTOs;
using LearnSphere.API.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearnSphere.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly CourseService _svc;
    public CoursesController(CourseService svc) => _svc = svc;

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll() => Ok(await _svc.GetAllAsync());

    [HttpGet("{id:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> Get(int id)
        => (await _svc.GetByIdAsync(id)) is CourseDto c ? Ok(c) : NotFound();

    [HttpPost]
    [Authorize(Roles = "Mentor,Admin")]
    public async Task<IActionResult> Create([FromBody] CourseDto dto)
        => Ok(await _svc.CreateAsync(dto));

    [HttpPut("{id:int}")]
    [Authorize(Roles = "Mentor,Admin")]
    public async Task<IActionResult> Update(int id, [FromBody] CourseDto dto)
        => (await _svc.UpdateAsync(id, dto)) ? NoContent() : NotFound();

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Mentor,Admin")]
    public async Task<IActionResult> Delete(int id)
        => (await _svc.DeleteAsync(id)) ? NoContent() : NotFound();
}
