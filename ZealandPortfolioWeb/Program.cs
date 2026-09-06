using ZealandPortfolioLib;
using ZealandPortfolioLib.Services;
using ZealandPortfolioLib.Repositories;
using ZealandPortfolioLib.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton<ProjectCategoryService>();
builder.Services.AddSingleton<ProjectService>();
builder.Services.AddSingleton<IGenericPageRepository<ProjectCategory>, GenericPageRepository<ProjectCategory>>();
builder.Services.AddSingleton<IGenericPageRepository<Project>, GenericPageRepository<Project>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
