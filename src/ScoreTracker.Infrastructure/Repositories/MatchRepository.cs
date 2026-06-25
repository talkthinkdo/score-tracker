using Microsoft.EntityFrameworkCore;
using ScoreTracker.Core.Interfaces.Repositories;
using ScoreTracker.Core.Models;
using ScoreTracker.Infrastructure.Data;

namespace ScoreTracker.Infrastructure.Repositories;

public class MatchRepository(AppDbContext context) : IMatchRepository
{
    public async Task<Match?> GetByIdAsync(int id)
        => await context.Matches
            .Include(m => m.HomeTeam)
            .Include(m => m.AwayTeam)
            .Include(m => m.Group)
            .FirstOrDefaultAsync(m => m.Id == id);

    public async Task<Match?> GetByIdWithGoalsAsync(int id)
        => await context.Matches
            .Include(m => m.HomeTeam)
            .Include(m => m.AwayTeam)
            .Include(m => m.Group)
            .Include(m => m.Goals)
                .ThenInclude(g => g.Team)
            .FirstOrDefaultAsync(m => m.Id == id);

    public async Task<IEnumerable<Match>> GetByGroupIdAsync(int groupId)
        => await context.Matches
            .Include(m => m.HomeTeam)
            .Include(m => m.AwayTeam)
            .Where(m => m.GroupId == groupId)
            .OrderBy(m => m.KickOff)
            .ToListAsync();

    public async Task UpdateAsync(Match match)
    {
        context.Matches.Update(match);
        await context.SaveChangesAsync();
    }
}
