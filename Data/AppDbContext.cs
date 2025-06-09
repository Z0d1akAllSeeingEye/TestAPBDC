namespace RaceParticipationAPI.Data;
using Microsoft.EntityFrameworkCore;
using RaceParticipationAPI.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Racer> Racers => Set<Racer>();
    public DbSet<Race> Races => Set<Race>();
    public DbSet<Track> Tracks => Set<Track>();
    public DbSet<TrackRace> TrackRaces => Set<TrackRace>();
    public DbSet<RaceParticipation> RaceParticipations => Set<RaceParticipation>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RaceParticipation>()
            .HasKey(rp => new { rp.RacerId, rp.TrackRaceId });

        
        modelBuilder.Entity<Racer>().HasData(
            new Racer { RacerId = 1, FirstName = "Lewis", LastName = "Hamilton" }
        );

        modelBuilder.Entity<Race>().HasData(
            new Race { RaceId = 1, Name = "British Grand Prix", Location = "Silverstone, UK", Date = new DateTime(2025, 7, 14) },
            new Race { RaceId = 2, Name = "Monaco Grand Prix", Location = "Monte Carlo, Monaco", Date = new DateTime(2025, 5, 25) }
        );

        modelBuilder.Entity<Track>().HasData(
            new Track { TrackId = 1, Name = "Silverstone Circuit", LengthInKm = 5.89m },
            new Track { TrackId = 2, Name = "Monaco Circuit", LengthInKm = 3.34m }
        );

        modelBuilder.Entity<TrackRace>().HasData(
            new TrackRace { TrackRaceId = 1, RaceId = 1, TrackId = 1, Laps = 52, BestTimeInSeconds = 5460 },
            new TrackRace { TrackRaceId = 2, RaceId = 2, TrackId = 2, Laps = 78, BestTimeInSeconds = 6300 }
        );

        modelBuilder.Entity<RaceParticipation>().HasData(
            new RaceParticipation { RacerId = 1, TrackRaceId = 1, Position = 1, FinishTimeInSeconds = 5460 },
            new RaceParticipation { RacerId = 1, TrackRaceId = 2, Position = 2, FinishTimeInSeconds = 6300 }
        );

        base.OnModelCreating(modelBuilder);
    }
}



