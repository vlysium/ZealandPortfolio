using ZealandPortfolioLib;
using ZealandPortfolioLib.Services;
using ZealandPortfolioLib.Repositories;
using ZealandPortfolioLib.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton<ProjectCategoryService>();
builder.Services.AddSingleton<ProjectService>();
builder.Services.AddSingleton<CommentService>();
builder.Services.AddSingleton<IGenericPageRepository<ProjectCategory>, GenericPageRepository<ProjectCategory>>();
builder.Services.AddSingleton<IGenericPageRepository<Project>, GenericPageRepository<Project>>();
builder.Services.AddSingleton<ICommentRepository, CommentRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/500");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseStatusCodePagesWithReExecute("/404");

app.UseAuthorization();

app.MapStaticAssets();

app.MapRazorPages().WithStaticAssets();

app.Run();
