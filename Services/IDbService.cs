namespace RaceParticipationAPI.Services;

using RaceParticipationAPI.DTOs;



public interface IDbService
{
    Task<RacerParticipationDto?> GetRacerParticipationAsync(int racerId);
    Task<(bool Success, string Message)> AddParticipantsAsync(AddParticipantsDto dto);
}