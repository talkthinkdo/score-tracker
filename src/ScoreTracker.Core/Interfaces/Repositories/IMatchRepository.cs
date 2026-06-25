using ScoreTracker.Core.Models;

namespace ScoreTracker.Core.Interfaces.Repositories;

public interface IMatchRepository
{
    Task<Match?> GetByIdAsync(int id);
    Task<Match?> GetByIdWithGoalsAsync(int id);
    Task<IEnumerable<Match>> GetByGroupIdAsync(int groupId);
    Task UpdateAsync(Match match);
}
