using Microsoft.EntityFrameworkCore;
using ScoreTracker.Core.Models;

namespace ScoreTracker.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Group> Groups => Set<Group>();
    public DbSet<Team> Teams => Set<Team>();
    public DbSet<Match> Matches => Set<Match>();
    public DbSet<Goal> Goals => Set<Goal>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Match>()
            .HasOne(m => m.HomeTeam)
            .WithMany()
            .HasForeignKey(m => m.HomeTeamId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Match>()
            .HasOne(m => m.AwayTeam)
            .WithMany()
            .HasForeignKey(m => m.AwayTeamId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Match>()
            .HasOne(m => m.Group)
            .WithMany(g => g.Matches)
            .HasForeignKey(m => m.GroupId);

        modelBuilder.Entity<Goal>()
            .HasOne(g => g.Team)
            .WithMany(t => t.Goals)
            .HasForeignKey(g => g.TeamId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
