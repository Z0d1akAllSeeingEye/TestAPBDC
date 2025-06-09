namespace RaceParticipationAPI.Services;
using RaceParticipationAPI.Data;
using RaceParticipationAPI.DTOs;
using RaceParticipationAPI.Models;
using Microsoft.EntityFrameworkCore;



public class DbService : IDbService
{
    private readonly AppDbContext _context;
    public DbService(AppDbContext context) => _context = context;

    public async Task<RacerParticipationDto?> GetRacerParticipationAsync(int racerId)
    {
        var racer = await _context.Racers
            .Include(r => r.Participations)
            .ThenInclude(p => p.TrackRace)
            .ThenInclude(tr => tr.Race)
            .Include(r => r.Participations)
            .ThenInclude(p => p.TrackRace)
            .ThenInclude(tr => tr.Track)
            .FirstOrDefaultAsync(r => r.RacerId == racerId);

        if (racer == null)
        {
            return null;
        }

        return new RacerParticipationDto
        {
            RacerId = racer.RacerId,
            FirstName = racer.FirstName,
            LastName = racer.LastName,
            Participations = racer.Participations.Select(p => new ParticipationDto
            {
                Race = new RaceDto
                {
                    Name = p.TrackRace.Race.Name,
                    Location = p.TrackRace.Race.Location,
                    Date = p.TrackRace.Race.Date
                },
                Track = new TrackDto
                {
                    Name = p.TrackRace.Track.Name,
                    LengthInKm = p.TrackRace.Track.LengthInKm
                },
                Laps = p.TrackRace.Laps,
                FinishTimeInSeconds = p.FinishTimeInSeconds,
                Position = p.Position
            }).ToList()
        };
    }

    public async Task<(bool Success, string Message)> AddParticipantsAsync(AddParticipantsDto dto)
    {
        var race = await _context.Races.FirstOrDefaultAsync(r => r.Name == dto.RaceName);
        var track = await _context.Tracks.FirstOrDefaultAsync(t => t.Name == dto.TrackName);

        if (race == null || track == null)
        {
            return (false, "Race or track not found");
        }

        var trackRace = await _context.TrackRaces
            .FirstOrDefaultAsync(tr => tr.RaceId == race.RaceId && tr.TrackId == track.TrackId);

        if (trackRace == null)
        {
            trackRace = new TrackRace
            {
                TrackId = track.TrackId,
                RaceId = race.RaceId,
                Laps = 50
            };
            _context.TrackRaces.Add(trackRace);
            await _context.SaveChangesAsync();
        }

        foreach (var p in dto.Participations)
        {
            var racer = await _context.Racers.FindAsync(p.RacerId);
            if (racer == null)
            {
                return (false, $"Racer {p.RacerId} not found");
            }
                

            _context.RaceParticipations.Add(new RaceParticipation
            {
                RacerId = p.RacerId,
                TrackRaceId = trackRace.TrackRaceId,
                FinishTimeInSeconds = p.FinishTimeInSeconds,
                Position = p.Position
            });

            if (trackRace.BestTimeInSeconds == null || p.FinishTimeInSeconds < trackRace.BestTimeInSeconds)
            {
                trackRace.BestTimeInSeconds = p.FinishTimeInSeconds;
            }
                
        }

        await _context.SaveChangesAsync();
        return (true, "Participants added");
    }
}