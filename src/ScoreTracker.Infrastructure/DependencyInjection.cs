using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ScoreTracker.Core.Interfaces.Repositories;
using ScoreTracker.Infrastructure.Data;
using ScoreTracker.Infrastructure.Repositories;

namespace ScoreTracker.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(opts =>
            opts.UseSqlite(connectionString));

        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<ITeamRepository, TeamRepository>();
        services.AddScoped<IMatchRepository, MatchRepository>();
        services.AddScoped<IGoalRepository, GoalRepository>();

        return services;
    }
}
