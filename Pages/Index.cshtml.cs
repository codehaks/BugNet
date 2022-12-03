using BugNet.Data;
using BugNet.Models;
using BugNet.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

    public void OnGet()
    {
        BugList = _bugService.GetAll();
        UnDoneCount = BugList.Count(b => b.IsDone == false);
    }
}
