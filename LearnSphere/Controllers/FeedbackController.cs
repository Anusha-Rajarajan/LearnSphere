using LearnSphere.API.DTOs;
using LearnSphere.API.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearnSphere.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeedbackController : ControllerBase
{
    private readonly FeedbackService _svc;
    public FeedbackController(FeedbackService svc) => _svc = svc;

    [HttpGet("mentor/{mentorId:int}")]
    public async Task<IActionResult> ForMentor(int mentorId) => Ok(await _svc.GetForMentorAsync(mentorId));

    [HttpPost]
    [Authorize(Roles = "Student,Admin")]
    public async Task<IActionResult> Create([FromBody] FeedbackDto dto) => Ok(await _svc.CreateAsync(dto));
}
