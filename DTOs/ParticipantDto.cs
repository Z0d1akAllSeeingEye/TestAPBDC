namespace RaceParticipationAPI.DTOs;


public class ParticipantDto
{
    public int RacerId { get; set; }
    public int FinishTimeInSeconds { get; set; }
    public int Position { get; set; }
}