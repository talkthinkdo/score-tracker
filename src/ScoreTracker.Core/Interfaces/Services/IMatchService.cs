using ScoreTracker.Core.Models;

namespace ScoreTracker.Core.Interfaces.Services;

public interface IMatchService
{
    Task<Match?> GetMatchAsync(int id);
    Task<Match?> GetMatchWithGoalsAsync(int id);
    Task UpdateResultAsync(int matchId, int homeScore, int awayScore, IEnumerable<Goal> goals);
}
