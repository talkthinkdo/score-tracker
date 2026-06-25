using ScoreTracker.Core.Models;

namespace ScoreTracker.Core.Interfaces.Repositories;

public interface ITeamRepository
{
    Task<Team?> GetByIdAsync(int id);
    Task<IEnumerable<Team>> GetByGroupIdAsync(int groupId);
}
