using BugNet.Data;
using BugNet.Service;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.FeatureManagement;
using System;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDbContext<BugDbContext>(options =>
{
    options.UseSqlite("Data Source=bugs.sqlite");
    options.LogTo(Console.WriteLine);
});

builder.Services.AddScoped<IBugService, BugService>();
builder.Services.AddFeatureManagement();


var app = builder.Build();

app.UseMiddlewareForFeature<StaticFileMiddleware>("staticfiles");
//app.UseStaticFiles();
app.MapRazorPages();
app.Run();
