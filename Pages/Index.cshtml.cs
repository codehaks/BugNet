using BugNet.Data;
using BugNet.Models;
using BugNet.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.FeatureManagement;

namespace BugNet.Pages;

public class IndexModel(IBugService bugService, ILogger<IndexModel> logger) : PageModel
{
    public IList<Bug> BugList { get; set; }
    public int UnDoneCount { get; set; }

    public bool IsDeleteAvailable { get; set; }

    public async Task<IActionResult> OnGet()
    {
        var numbers = new List<int> [1, 5, 7];


        BugList = [];

        logger.LogInformation("Reading started!");
        BugList = bugService.GetAll();
        UnDoneCount = BugList.Count(b => b.IsDone == false);
        logger.LogInformation("Reading finished!");
        return Page();
    }
}
