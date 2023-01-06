using BugNet.Data;
using BugNet.Models;
using BugNet.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.FeatureManagement;

namespace BugNet.Pages;

public class IndexModel : PageModel
{
    private readonly IBugService _bugService;

    public IndexModel(IBugService bugService)
    {
        _bugService = bugService;
    }

    public IList<Bug> BugList { get; set; }
    public int UnDoneCount { get; set; }

    public bool IsDeleteAvailable { get; set; }

    public async Task<IActionResult> OnGet()
    {
        BugList = _bugService.GetAll();
        UnDoneCount = BugList.Count(b => b.IsDone == false);
        return Page();
    }
}
