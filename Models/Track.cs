namespace RaceParticipationAPI.Models;

public class Track
{
    public int TrackId { get; set; }
    public string Name { get; set; }
    public decimal LengthInKm { get; set; }
    public ICollection<TrackRace> TrackRaces { get; set; }
}