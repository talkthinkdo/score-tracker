using Microsoft.AspNetCore.Mvc;
using ScoreTracker.Core.Interfaces.Services;
using ScoreTracker.Web.Services;
using ScoreTracker.Web.ViewModels;

namespace ScoreTracker.Web.Controllers;

public class GroupController(IGroupService groupService) : Controller
{
    public async Task<IActionResult> Detail(int id)
    {
        var group = await groupService.GetGroupAsync(id);
        if (group is null) return NotFound();

        var standings = GroupService.CalculateStandings(group);
        var matches = group.Matches.OrderBy(m => m.KickOff);

        return View(new GroupViewModel
        {
            Group = group,
            Standings = standings,
            Matches = matches,
        });
    }
}
