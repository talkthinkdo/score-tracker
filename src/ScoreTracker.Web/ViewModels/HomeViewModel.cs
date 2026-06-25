using ScoreTracker.Core.Models;

namespace ScoreTracker.Web.ViewModels;

public class HomeViewModel
{
    public IEnumerable<GroupSummaryViewModel> Groups { get; set; } = [];
}

public class GroupSummaryViewModel
{
    public Group Group { get; set; } = null!;
    public IEnumerable<GroupStanding> Standings { get; set; } = [];
    public IEnumerable<Match> RecentMatches { get; set; } = [];
}
