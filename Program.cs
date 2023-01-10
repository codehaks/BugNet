using BugNet.Data;
using BugNet.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDbContext<BugDbContext>(options =>
{
    options.UseSqlite(builder.Configuration["Database"]);
    options.LogTo(Console.WriteLine,LogLevel.Information);
});

builder.Services.AddScoped<IBugService, BugService>();

var app = builder.Build();

app.Logger.LogInformation("This is a test log!"); 


if (app.Environment.IsProduction())
{
    app.UseStatusCodePagesWithReExecute("/code/{0}");
    app.UseExceptionHandler("/error");
}


app.UseStaticFiles();
app.MapRazorPages();
app.Run();
