using FluentAssertions;
using Moq;
using ScoreTracker.Core.Interfaces.Repositories;
using ScoreTracker.Core.Models;
using ScoreTracker.Web.Services;
using Match = ScoreTracker.Core.Models.Match;

namespace ScoreTracker.Tests.Services;

public class GroupServiceTests
{
    private static Group BuildGroup(params (int teamId, string name)[] teams)
    {
        var group = new Group { Id = 1, Name = "A" };
        group.Teams = teams.Select(t => new Team { Id = t.teamId, Name = t.name, GroupId = 1 }).ToList();
        group.Matches = new List<Match>();
        return group;
    }

    private static Match CompletedMatch(int id, int homeId, int awayId, int homeScore, int awayScore) =>
        new()
        {
            Id = id,
            GroupId = 1,
            HomeTeamId = homeId,
            AwayTeamId = awayId,
            HomeScore = homeScore,
            AwayScore = awayScore,
            Status = MatchStatus.Completed,
        };

    [Fact]
    public void CalculateStandings_AllScheduled_AllTeamsZeroPoints()
    {
        var group = BuildGroup((1, "Team A"), (2, "Team B"), (3, "Team C"), (4, "Team D"));

        var standings = GroupService.CalculateStandings(group).ToList();

        standings.Should().HaveCount(4);
        standings.Should().AllSatisfy(s =>
        {
            s.Points.Should().Be(0);
            s.Played.Should().Be(0);
        });
    }

    [Fact]
    public void CalculateStandings_Win_Awards3PointsToWinner()
    {
        var group = BuildGroup((1, "Team A"), (2, "Team B"), (3, "Team C"), (4, "Team D"));
        group.Matches.Add(CompletedMatch(1, homeId: 1, awayId: 2, homeScore: 2, awayScore: 0));

        var standings = GroupService.CalculateStandings(group).ToList();
        var teamA = standings.First(s => s.Team.Id == 1);
        var teamB = standings.First(s => s.Team.Id == 2);

        teamA.Points.Should().Be(3);
        teamA.Won.Should().Be(1);
        teamA.Lost.Should().Be(0);
        teamB.Points.Should().Be(0);
        teamB.Lost.Should().Be(1);
    }

    [Fact]
    public void CalculateStandings_Draw_Awards1PointEach()
    {
        var group = BuildGroup((1, "Team A"), (2, "Team B"), (3, "Team C"), (4, "Team D"));
        group.Matches.Add(CompletedMatch(1, homeId: 1, awayId: 2, homeScore: 1, awayScore: 1));

        var standings = GroupService.CalculateStandings(group).ToList();
        var teamA = standings.First(s => s.Team.Id == 1);
        var teamB = standings.First(s => s.Team.Id == 2);

        teamA.Points.Should().Be(1);
        teamA.Drawn.Should().Be(1);
        teamB.Points.Should().Be(1);
        teamB.Drawn.Should().Be(1);
    }

    [Fact]
    public void CalculateStandings_GoalDifferenceCalculatedCorrectly()
    {
        var group = BuildGroup((1, "Team A"), (2, "Team B"), (3, "Team C"), (4, "Team D"));
        group.Matches.Add(CompletedMatch(1, homeId: 1, awayId: 2, homeScore: 3, awayScore: 1));

        var standings = GroupService.CalculateStandings(group).ToList();
        var teamA = standings.First(s => s.Team.Id == 1);
        var teamB = standings.First(s => s.Team.Id == 2);

        teamA.GoalDifference.Should().Be(2);
        teamB.GoalDifference.Should().Be(-2);
    }

    [Fact]
    public void CalculateStandings_OrderedByPointsThenGoalDifferenceThenGoalsFor()
    {
        var group = BuildGroup((1, "A"), (2, "B"), (3, "C"), (4, "D"));
        // Team 1: 3pts, GD +2
        group.Matches.Add(CompletedMatch(1, homeId: 1, awayId: 2, homeScore: 2, awayScore: 0));
        // Team 3: 3pts, GD +1
        group.Matches.Add(CompletedMatch(2, homeId: 3, awayId: 4, homeScore: 1, awayScore: 0));

        var standings = GroupService.CalculateStandings(group).ToList();

        standings[0].Team.Id.Should().Be(1);
        standings[1].Team.Id.Should().Be(3);
    }

    [Fact]
    public async Task GetStandingsAsync_ReturnsEmptyForUnknownGroup()
    {
        var repoMock = new Mock<IGroupRepository>();
        repoMock.Setup(r => r.GetByIdWithMatchesAsync(It.IsAny<int>())).ReturnsAsync((Group?)null);

        var service = new GroupService(repoMock.Object);
        var result = await service.GetStandingsAsync(999);

        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GetAllGroupsAsync_DelegatesToRepository()
    {
        var expected = new List<Group> { new() { Id = 1, Name = "A" } };
        var repoMock = new Mock<IGroupRepository>();
        repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(expected);

        var service = new GroupService(repoMock.Object);
        var result = await service.GetAllGroupsAsync();

        result.Should().BeEquivalentTo(expected);
    }
}
