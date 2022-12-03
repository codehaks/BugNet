using BugNet.Data;
using BugNet.Models;
using BugNet.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BugNet.Pages;

public class CreateModel : PageModel
{
    private readonly IBugService _bugService;

    public CreateModel(IBugService bugService)
    {
        _bugService = bugService;
    }

    [BindProperty]
    public string Name { get; set; }

    [BindProperty]
    public string Description { get; set; }
    public IActionResult OnPost()
    {
        _bugService.Create(new Bug
        {
            Name = Name,
            Description = Description,
            IsDone = false
        });

        TempData["message"] = "New bug created!";

        return RedirectToPage("./index");
    }
}
