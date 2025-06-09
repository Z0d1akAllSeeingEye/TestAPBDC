namespace RaceParticipationAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
using RaceParticipationAPI.DTOs;
using RaceParticipationAPI.Services;



[ApiController]
[Route("api/track-races")]
public class TrackRacesController : ControllerBase
{
    private readonly IDbService _service;

    public TrackRacesController(IDbService service)
    {
        _service = service;
    }

  
    [HttpPost("participants")]
    public async Task<IActionResult> AddParticipants([FromBody] AddParticipantsDto dto)
    {
        var (success, message) = await _service.AddParticipantsAsync(dto);
        if (!success)
            return BadRequest(new { error = message });

        return Created(string.Empty, null);
    }
}