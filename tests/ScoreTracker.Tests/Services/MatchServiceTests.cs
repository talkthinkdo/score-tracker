using FluentAssertions;
using Moq;
using ScoreTracker.Core.Interfaces.Repositories;
using ScoreTracker.Core.Models;
using ScoreTracker.Web.Services;
using Match = ScoreTracker.Core.Models.Match;

namespace ScoreTracker.Tests.Services;

public class MatchServiceTests
{
    private readonly Mock<IMatchRepository> _matchRepo = new();
    private readonly Mock<IGoalRepository> _goalRepo = new();

    private MatchService CreateService() => new(_matchRepo.Object, _goalRepo.Object);

    [Fact]
    public async Task GetAllMatchesAsync_ReturnsAllMatches()
    {
        var matches = new List<Match>
        {
            new() { Id = 1, HomeTeamId = 1, AwayTeamId = 2 },
            new() { Id = 2, HomeTeamId = 3, AwayTeamId = 4 },
        };
        _matchRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(matches);

        var result = await CreateService().GetAllMatchesAsync();

        result.Should().BeEquivalentTo(matches);
    }

    [Fact]
    public async Task GetAllMatchesAsync_ReturnsEmpty_WhenNoMatches()
    {
        _matchRepo.Setup(r => r.GetAllAsync()).ReturnsAsync([]);

        var result = await CreateService().GetAllMatchesAsync();

        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GetMatchAsync_ReturnsNull_WhenNotFound()
    {
        _matchRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Match?)null);

        var result = await CreateService().GetMatchAsync(99);

        result.Should().BeNull();
    }

    [Fact]
    public async Task GetMatchWithGoalsAsync_ReturnsMatch_WhenExists()
    {
        var match = new Match { Id = 1, HomeTeamId = 1, AwayTeamId = 2 };
        _matchRepo.Setup(r => r.GetByIdWithGoalsAsync(1)).ReturnsAsync(match);

        var result = await CreateService().GetMatchWithGoalsAsync(1);

        result.Should().Be(match);
    }

    [Fact]
    public async Task UpdateResultAsync_SetsScoreAndStatusCompleted()
    {
        var match = new Match { Id = 1, HomeTeamId = 1, AwayTeamId = 2, Status = MatchStatus.Scheduled };
        _matchRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(match);
        _goalRepo.Setup(r => r.DeleteByMatchIdAsync(1)).Returns(Task.CompletedTask);
        _goalRepo.Setup(r => r.AddAsync(It.IsAny<Goal>())).Returns(Task.CompletedTask);
        _matchRepo.Setup(r => r.UpdateAsync(match)).Returns(Task.CompletedTask);

        await CreateService().UpdateResultAsync(1, homeScore: 3, awayScore: 1, goals: []);

        match.HomeScore.Should().Be(3);
        match.AwayScore.Should().Be(1);
        match.Status.Should().Be(MatchStatus.Completed);
    }

    [Fact]
    public async Task UpdateResultAsync_DeletesExistingGoalsBeforeAdding()
    {
        var match = new Match { Id = 5, HomeTeamId = 1, AwayTeamId = 2 };
        _matchRepo.Setup(r => r.GetByIdAsync(5)).ReturnsAsync(match);
        _matchRepo.Setup(r => r.UpdateAsync(match)).Returns(Task.CompletedTask);

        var deleteOrder = new List<string>();
        _goalRepo.Setup(r => r.DeleteByMatchIdAsync(5))
            .Callback(() => deleteOrder.Add("delete"))
            .Returns(Task.CompletedTask);
        _goalRepo.Setup(r => r.AddAsync(It.IsAny<Goal>()))
            .Callback(() => deleteOrder.Add("add"))
            .Returns(Task.CompletedTask);

        var newGoals = new[] { new Goal { ScorerName = "Test", Minute = 45, TeamId = 1 } };
        await CreateService().UpdateResultAsync(5, 1, 0, newGoals);

        deleteOrder[0].Should().Be("delete");
        deleteOrder[1].Should().Be("add");
    }

    [Fact]
    public async Task UpdateResultAsync_ThrowsWhenMatchNotFound()
    {
        _matchRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Match?)null);

        var act = async () => await CreateService().UpdateResultAsync(99, 0, 0, []);

        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("*99*");
    }

    [Fact]
    public async Task UpdateResultAsync_AssignsMatchIdToEachGoal()
    {
        var match = new Match { Id = 7, HomeTeamId = 1, AwayTeamId = 2 };
        _matchRepo.Setup(r => r.GetByIdAsync(7)).ReturnsAsync(match);
        _matchRepo.Setup(r => r.UpdateAsync(match)).Returns(Task.CompletedTask);
        _goalRepo.Setup(r => r.DeleteByMatchIdAsync(7)).Returns(Task.CompletedTask);

        var capturedGoals = new List<Goal>();
        _goalRepo.Setup(r => r.AddAsync(It.IsAny<Goal>()))
            .Callback<Goal>(capturedGoals.Add)
            .Returns(Task.CompletedTask);

        var goals = new[]
        {
            new Goal { ScorerName = "Pulisic", Minute = 10, TeamId = 1 },
            new Goal { ScorerName = "Reyna",   Minute = 55, TeamId = 1 },
        };
        await CreateService().UpdateResultAsync(7, 2, 0, goals);

        capturedGoals.Should().AllSatisfy(g => g.MatchId.Should().Be(7));
    }
}
