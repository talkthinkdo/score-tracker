using Microsoft.EntityFrameworkCore;
using ScoreTracker.Core.Interfaces.Repositories;
using ScoreTracker.Core.Models;
using ScoreTracker.Infrastructure.Data;

namespace ScoreTracker.Infrastructure.Repositories;

public class GroupRepository(AppDbContext context) : IGroupRepository
{
    public async Task<IEnumerable<Group>> GetAllAsync()
        => await context.Groups
            .Include(g => g.Teams)
            .Include(g => g.Matches)
                .ThenInclude(m => m.HomeTeam)
            .Include(g => g.Matches)
                .ThenInclude(m => m.AwayTeam)
            .OrderBy(g => g.Name)
            .ToListAsync();

    public async Task<Group?> GetByIdAsync(int id)
        => await context.Groups
            .Include(g => g.Teams)
            .FirstOrDefaultAsync(g => g.Id == id);

    public async Task<Group?> GetByIdWithMatchesAsync(int id)
        => await context.Groups
            .Include(g => g.Teams)
            .Include(g => g.Matches)
                .ThenInclude(m => m.HomeTeam)
            .Include(g => g.Matches)
                .ThenInclude(m => m.AwayTeam)
            .Include(g => g.Matches)
                .ThenInclude(m => m.Goals)
            .FirstOrDefaultAsync(g => g.Id == id);
}
