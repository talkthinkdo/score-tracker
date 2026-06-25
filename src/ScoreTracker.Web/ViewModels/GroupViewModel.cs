using ScoreTracker.Core.Models;

namespace ScoreTracker.Web.ViewModels;

public class GroupViewModel
{
    public Group Group { get; set; } = null!;
    public IEnumerable<GroupStanding> Standings { get; set; } = [];
    public IEnumerable<Match> Matches { get; set; } = [];
}
