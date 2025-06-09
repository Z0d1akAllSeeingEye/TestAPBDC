namespace RaceParticipationAPI.Controllers;
using RaceParticipationAPI.Services;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/racers")]
public class RacersController : ControllerBase
{
    private readonly IDbService _service;
    public RacersController(IDbService service) => _service = service;

    [HttpGet("{id}/participations")]
    public async Task<ActionResult> GetParticipations(int id)
    {
        var result = await _service.GetRacerParticipationAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
    
}


