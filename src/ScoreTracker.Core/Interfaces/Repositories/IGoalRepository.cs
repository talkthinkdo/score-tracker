using ScoreTracker.Core.Models;

namespace ScoreTracker.Core.Interfaces.Repositories;

public interface IGoalRepository
{
    Task<IEnumerable<Goal>> GetByMatchIdAsync(int matchId);
    Task AddAsync(Goal goal);
    Task DeleteByMatchIdAsync(int matchId);
}
