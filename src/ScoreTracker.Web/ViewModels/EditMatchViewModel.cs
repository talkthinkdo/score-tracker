using System.ComponentModel.DataAnnotations;
using ScoreTracker.Core.Models;

namespace ScoreTracker.Web.ViewModels;

public class EditMatchViewModel
{
    public int MatchId { get; set; }
    public string HomeTeamName { get; set; } = string.Empty;
    public string AwayTeamName { get; set; } = string.Empty;
    public int HomeTeamId { get; set; }
    public int AwayTeamId { get; set; }

    [Range(0, 99, ErrorMessage = "Score must be between 0 and 99.")]
    public int HomeScore { get; set; }

    [Range(0, 99, ErrorMessage = "Score must be between 0 and 99.")]
    public int AwayScore { get; set; }

    public List<GoalEntry> Goals { get; set; } = [];
}

public class GoalEntry
{
    [Required]
    public string ScorerName { get; set; } = string.Empty;

    [Range(1, 120)]
    public int Minute { get; set; }

    public int TeamId { get; set; }
    public bool IsOwnGoal { get; set; }
    public bool IsPenalty { get; set; }
}
