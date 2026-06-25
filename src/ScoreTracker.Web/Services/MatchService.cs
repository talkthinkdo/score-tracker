using ScoreTracker.Core.Interfaces.Repositories;
using ScoreTracker.Core.Interfaces.Services;
using ScoreTracker.Core.Models;

namespace ScoreTracker.Web.Services;

public class MatchService(IMatchRepository matchRepository, IGoalRepository goalRepository) : IMatchService
{
    public async Task<IEnumerable<Match>> GetAllMatchesAsync()
        => await matchRepository.GetAllAsync();

    public async Task<Match?> GetMatchAsync(int id)
        => await matchRepository.GetByIdAsync(id);

    public async Task<Match?> GetMatchWithGoalsAsync(int id)
        => await matchRepository.GetByIdWithGoalsAsync(id);

    public async Task UpdateResultAsync(int matchId, int homeScore, int awayScore, IEnumerable<Goal> goals)
    {
        var match = await matchRepository.GetByIdAsync(matchId)
            ?? throw new InvalidOperationException($"Match {matchId} not found.");

        match.HomeScore = homeScore;
        match.AwayScore = awayScore;
        match.Status = MatchStatus.Completed;

        await goalRepository.DeleteByMatchIdAsync(matchId);

        foreach (var goal in goals)
        {
            goal.MatchId = matchId;
            await goalRepository.AddAsync(goal);
        }

        await matchRepository.UpdateAsync(match);
    }
}
