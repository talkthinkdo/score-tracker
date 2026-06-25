using ScoreTracker.Core.Interfaces.Repositories;
using ScoreTracker.Core.Interfaces.Services;
using ScoreTracker.Core.Models;

namespace ScoreTracker.Web.Services;

public class GroupService(IGroupRepository groupRepository) : IGroupService
{
    public async Task<IEnumerable<Group>> GetAllGroupsAsync()
        => await groupRepository.GetAllAsync();

    public async Task<Group?> GetGroupAsync(int id)
        => await groupRepository.GetByIdWithMatchesAsync(id);

    public async Task<IEnumerable<GroupStanding>> GetStandingsAsync(int groupId)
    {
        var group = await groupRepository.GetByIdWithMatchesAsync(groupId);
        if (group is null) return [];

        return CalculateStandings(group);
    }

    public static IEnumerable<GroupStanding> CalculateStandings(Group group)
    {
        var standings = group.Teams.ToDictionary(t => t.Id, t => new GroupStanding { Team = t });

        foreach (var match in group.Matches.Where(m => m.Status == MatchStatus.Completed))
        {
            if (match.HomeScore is null || match.AwayScore is null) continue;

            var home = standings[match.HomeTeamId];
            var away = standings[match.AwayTeamId];

            home.Played++;
            away.Played++;
            home.GoalsFor += match.HomeScore.Value;
            home.GoalsAgainst += match.AwayScore.Value;
            away.GoalsFor += match.AwayScore.Value;
            away.GoalsAgainst += match.HomeScore.Value;

            if (match.HomeScore > match.AwayScore)
            {
                home.Won++;
                away.Lost++;
            }
            else if (match.HomeScore < match.AwayScore)
            {
                away.Won++;
                home.Lost++;
            }
            else
            {
                home.Drawn++;
                away.Drawn++;
            }
        }

        return standings.Values
            .OrderByDescending(s => s.Points)
            .ThenByDescending(s => s.GoalDifference)
            .ThenByDescending(s => s.GoalsFor)
            .ThenBy(s => s.Team.Name);
    }
}
