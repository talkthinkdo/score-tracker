using Microsoft.EntityFrameworkCore;
using ScoreTracker.Core.Interfaces.Repositories;
using ScoreTracker.Core.Models;
using ScoreTracker.Infrastructure.Data;

namespace ScoreTracker.Infrastructure.Repositories;

public class TeamRepository(AppDbContext context) : ITeamRepository
{
    public async Task<Team?> GetByIdAsync(int id)
        => await context.Teams.FindAsync(id);

    public async Task<IEnumerable<Team>> GetByGroupIdAsync(int groupId)
        => await context.Teams.Where(t => t.GroupId == groupId).ToListAsync();
}
