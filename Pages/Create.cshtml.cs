using BugNet.Data;
using BugNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BugNet.Pages;

public class CreateModel : PageModel
{
    private readonly BugDbContext _db;

    public CreateModel(BugDbContext db)
    {
        _db = db;
    }

    [BindProperty]
    public string Name { get; set; }

    [BindProperty]
    public string Description { get; set; }
    public IActionResult OnPost()
    {
        _db.Bugs.Add(new Bug
        {
            Name = Name,
            Description = Description,
            IsDone=false
        });

        _db.SaveChanges();

        TempData["message"] = "New bug created!";

        return RedirectToPage("./index");
    }
}
