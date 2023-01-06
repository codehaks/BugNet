using BugNet.Data;
using BugNet.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDbContext<BugDbContext>(options =>
{
    options.UseSqlite("Data Source=bugs.sqlite");
    options.LogTo(Console.WriteLine);
});

builder.Services.AddScoped<IBugService, BugService>();

var app = builder.Build();

app.UseStaticFiles();
app.MapRazorPages();
app.Run();
