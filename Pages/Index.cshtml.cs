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
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(IBugService bugService, ILogger<IndexModel> logger)
    {
        _bugService = bugService;
        _logger = logger;
    }

    public IList<Bug> BugList { get; set; }
    public int UnDoneCount { get; set; }

    public bool IsDeleteAvailable { get; set; }

    public async Task<IActionResult> OnGet()
    {
        _logger.LogInformation("Reading started!");
        BugList = _bugService.GetAll();
        UnDoneCount = BugList.Count(b => b.IsDone == false);
        _logger.LogInformation("Reading finished!");
        return Page();
    }
}
