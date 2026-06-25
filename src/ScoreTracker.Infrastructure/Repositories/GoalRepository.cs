using Microsoft.EntityFrameworkCore;
using ScoreTracker.Core.Interfaces.Repositories;
using ScoreTracker.Core.Models;
using ScoreTracker.Infrastructure.Data;

namespace ScoreTracker.Infrastructure.Repositories;

public class GoalRepository(AppDbContext context) : IGoalRepository
{
    public async Task<IEnumerable<Goal>> GetByMatchIdAsync(int matchId)
        => await context.Goals
            .Include(g => g.Team)
            .Where(g => g.MatchId == matchId)
            .OrderBy(g => g.Minute)
            .ToListAsync();

    public async Task AddAsync(Goal goal)
    {
        await context.Goals.AddAsync(goal);
        await context.SaveChangesAsync();
    }

    public async Task DeleteByMatchIdAsync(int matchId)
    {
        var goals = context.Goals.Where(g => g.MatchId == matchId);
        context.Goals.RemoveRange(goals);
        await context.SaveChangesAsync();
    }
}
