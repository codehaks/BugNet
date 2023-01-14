using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BugNet.Pages;

public class ContactModel : PageModel
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ContactModel(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult OnGet()
    {
        var root = _webHostEnvironment.ContentRootPath;

        
        //var p=root+ "\\"+"flower2.jpg";
        var flowerPath = Path.Combine(root,"Files", "flower2.jpg");

        var bytes=System.IO.File.ReadAllBytes(flowerPath); 

        return File(bytes, "image/jpeg");
    }
}
