using BugNet.Data;
using BugNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.FeatureManagement.Mvc;

namespace BugNet.Pages;
public class DeleteModel : PageModel
{
    private readonly BugDbContext _db;

    public DeleteModel(BugDbContext db)
    {
        _db = db;
    }

    [BindProperty]
    public Bug? SelectedBug { get; set; }

    public void OnGet(int id)
    {
        SelectedBug = _db.Bugs.Find(id);
    }

    public IActionResult OnPost()
    {
        var bug = _db.Bugs.Find(SelectedBug.Id);

        _db.Bugs.Remove(bug);

        _db.SaveChanges();

        TempData["message"] = "Bug removed successfully.";

        return RedirectToPage("./index");
    }
}
