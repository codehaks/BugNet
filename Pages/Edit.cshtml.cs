using BugNet.Data;
using BugNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace BugNet.Pages;

public class EditModel : PageModel
{
    private readonly BugDbContext _db;

    public EditModel(BugDbContext db)
    {
        _db = db;
    }

    [BindProperty]
    public Bug? SelectedBug { get; set; }

    public void OnGet(BugId id)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(id);
        
        SelectedBug = _db.Bugs.Find(id);
    }

    public IActionResult OnPost()
    {
        var bug = _db.Bugs.Find(SelectedBug.Id);

        bug.Name = SelectedBug.Name;
        bug.Description = SelectedBug.Description;
        bug.IsDone = SelectedBug.IsDone;

        _db.SaveChanges();

        return RedirectToPage("./index");
    }
}
