using Microsoft.AspNetCore.Mvc;
using ScoreTracker.Core.Interfaces.Services;
using ScoreTracker.Core.Models;
using ScoreTracker.Web.ViewModels;

namespace ScoreTracker.Web.Controllers;

public class MatchController(IMatchService matchService) : Controller
{
    public async Task<IActionResult> Detail(int id)
    {
        var match = await matchService.GetMatchWithGoalsAsync(id);
        if (match is null) return NotFound();

        return View(new MatchViewModel
        {
            Match = match,
            HomeGoals = match.Goals
                .Where(g => (g.TeamId == match.HomeTeamId && !g.IsOwnGoal)
                         || (g.TeamId == match.AwayTeamId && g.IsOwnGoal))
                .OrderBy(g => g.Minute),
            AwayGoals = match.Goals
                .Where(g => (g.TeamId == match.AwayTeamId && !g.IsOwnGoal)
                         || (g.TeamId == match.HomeTeamId && g.IsOwnGoal))
                .OrderBy(g => g.Minute),
        });
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var match = await matchService.GetMatchWithGoalsAsync(id);
        if (match is null) return NotFound();

        var vm = new EditMatchViewModel
        {
            MatchId = match.Id,
            HomeTeamName = match.HomeTeam.Name,
            AwayTeamName = match.AwayTeam.Name,
            HomeTeamId = match.HomeTeamId,
            AwayTeamId = match.AwayTeamId,
            HomeScore = match.HomeScore ?? 0,
            AwayScore = match.AwayScore ?? 0,
            Goals = match.Goals.OrderBy(g => g.Minute).Select(g => new GoalEntry
            {
                ScorerName = g.ScorerName,
                Minute = g.Minute,
                TeamId = g.TeamId,
                IsOwnGoal = g.IsOwnGoal,
                IsPenalty = g.IsPenalty,
            }).ToList(),
        };

        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(EditMatchViewModel vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var goals = vm.Goals.Select(g => new Goal
        {
            ScorerName = g.ScorerName,
            Minute = g.Minute,
            TeamId = g.TeamId,
            IsOwnGoal = g.IsOwnGoal,
            IsPenalty = g.IsPenalty,
        });

        await matchService.UpdateResultAsync(vm.MatchId, vm.HomeScore, vm.AwayScore, goals);

        return RedirectToAction("Detail", new { id = vm.MatchId });
    }
}
