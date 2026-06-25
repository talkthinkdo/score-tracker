using ScoreTracker.Core.Models;

namespace ScoreTracker.Web.ViewModels;

public class MatchViewModel
{
    public Match Match { get; set; } = null!;
    public IEnumerable<Goal> HomeGoals { get; set; } = [];
    public IEnumerable<Goal> AwayGoals { get; set; } = [];
}
