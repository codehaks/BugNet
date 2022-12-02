using BugNet.Data;
using BugNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BugNet.Pages;

public class IndexModel : PageModel
{
    private readonly BugDbContext _db;

    public IndexModel(BugDbContext db)
    {
        _db = db;
    }

    public IList<Bug> BugList { get; set; }
    public int UnDoneCount { get; set; }

    public void OnGet()
    {
        BugList = _db.Bugs.ToList();
        UnDoneCount = BugList.Count(b => b.IsDone == false);
    }
}
