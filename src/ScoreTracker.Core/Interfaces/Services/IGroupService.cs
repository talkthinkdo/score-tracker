using ScoreTracker.Core.Models;

namespace ScoreTracker.Core.Interfaces.Services;

public interface IGroupService
{
    Task<IEnumerable<Group>> GetAllGroupsAsync();
    Task<Group?> GetGroupAsync(int id);
    Task<IEnumerable<GroupStanding>> GetStandingsAsync(int groupId);
}
