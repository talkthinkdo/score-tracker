namespace ScoreTracker.Core.Models;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string FifaCode { get; set; } = string.Empty;
    public string Confederation { get; set; } = string.Empty;

    public int GroupId { get; set; }
    public Group Group { get; set; } = null!;

    public ICollection<Goal> Goals { get; set; } = new List<Goal>();
}
