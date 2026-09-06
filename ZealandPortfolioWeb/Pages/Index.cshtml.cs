using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandPortfolioLib;
using ZealandPortfolioLib.Services;

namespace ZealandPortfolioWeb.Pages;

public class IndexModel : PageModel
{
    /// <summary>
    /// The service for accessing project categories.
    /// </summary>
    private readonly ProjectCategoryService _projectCategoryService;

    /// <summary>
    /// Gets or sets the list of project categories to be displayed on the index page.
    /// </summary>
    public List<ProjectCategory> ProjectCategories { get; set; } = new List<ProjectCategory>();

    /// <summary>
    /// Initializes a new instance of the <see cref="IndexModel"/> class with the specified project category service.
    /// </summary>
    /// <param name="projectCategoryService">The project category service to use.</param>
    public IndexModel(ProjectCategoryService projectCategoryService)
    {
        _projectCategoryService = projectCategoryService;
    }

    public void OnGet()
    {
        ProjectCategories = _projectCategoryService.GetAllProjectCategories();
    }
}
