namespace ScoreTracker.Core.Models;

public class Match
{
    public int Id { get; set; }

    public int GroupId { get; set; }
    public Group Group { get; set; } = null!;

    public int HomeTeamId { get; set; }
    public Team HomeTeam { get; set; } = null!;

    public int AwayTeamId { get; set; }
    public Team AwayTeam { get; set; } = null!;

    public DateTime KickOff { get; set; }
    public string Venue { get; set; } = string.Empty;

    public int? HomeScore { get; set; }
    public int? AwayScore { get; set; }

    public MatchStatus Status { get; set; } = MatchStatus.Scheduled;

    public ICollection<Goal> Goals { get; set; } = new List<Goal>();
}
