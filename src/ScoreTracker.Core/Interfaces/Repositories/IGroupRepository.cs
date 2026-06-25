using ScoreTracker.Core.Models;

namespace ScoreTracker.Core.Interfaces.Repositories;

public interface IGroupRepository
{
    Task<IEnumerable<Group>> GetAllAsync();
    Task<Group?> GetByIdAsync(int id);
    Task<Group?> GetByIdWithMatchesAsync(int id);
}
