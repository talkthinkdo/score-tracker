using Microsoft.AspNetCore.Mvc;
using ScoreTracker.Core.Interfaces.Services;
using ScoreTracker.Web.Services;
using ScoreTracker.Web.ViewModels;

namespace ScoreTracker.Web.Controllers;

public class HomeController(IGroupService groupService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var groups = await groupService.GetAllGroupsAsync();

        var summaries = new List<GroupSummaryViewModel>();
        foreach (var group in groups)
        {
            var standings = GroupService.CalculateStandings(group);
            summaries.Add(new GroupSummaryViewModel
            {
                Group = group,
                Standings = standings,
                RecentMatches = group.Matches
                    .Where(m => m.Status == Core.Models.MatchStatus.Completed)
                    .OrderByDescending(m => m.KickOff)
                    .Take(2),
            });
        }

        return View(new HomeViewModel { Groups = summaries });
    }
}
