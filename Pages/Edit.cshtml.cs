using BugNet.Data;
using BugNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BugNet.Pages;

public class EditModel : PageModel
{
    private readonly BugDbContext _db;

    public Bug? SelectedBug { get; set; }

    public void OnGet(int id)
    {
        SelectedBug = _db.Bugs.Find(id);
    }
}
