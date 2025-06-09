namespace RaceParticipationAPI.DTOs;

public class AddParticipantsDto
{
    public string RaceName { get; set; }
    public string TrackName { get; set; }
    public List<ParticipantDto> Participations { get; set; }
}
