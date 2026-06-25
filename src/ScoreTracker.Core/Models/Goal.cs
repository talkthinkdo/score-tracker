namespace ScoreTracker.Core.Models;

public class Goal
{
    public int Id { get; set; }

    public int MatchId { get; set; }
    public Match Match { get; set; } = null!;

    public int TeamId { get; set; }
    public Team Team { get; set; } = null!;

    public string ScorerName { get; set; } = string.Empty;
    public int Minute { get; set; }
    public bool IsOwnGoal { get; set; }
    public bool IsPenalty { get; set; }
}
