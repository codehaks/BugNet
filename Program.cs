using BugNet.Data;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDbContext<BugDbContext>(options =>
{
    options.UseSqlite("Data Source=bugs.sqlite");
    options.LogTo(Console.WriteLine);
});

var app = builder.Build();
app.UseStaticFiles();
app.MapRazorPages();
app.Run();
