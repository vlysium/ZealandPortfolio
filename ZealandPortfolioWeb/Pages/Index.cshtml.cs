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
    /// Gets or sets the display text for the number of days until graduation.
    /// </summary>
    public string? DisplayDaysUntilGradiation { get; set; }

    /// <summary>
    /// Gets or sets the number of years of age.
    /// </summary>
    public string YearsOfAge { get; init; } = Math.Floor((DateTime.Now - new DateTime(2000, 12, 23)).TotalDays / 365.25).ToString();

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

        int DaysUntilGraduation = new DateTime(2028, 6, 30).Subtract(DateTime.Today).Days;
        switch (DaysUntilGraduation)
        {
            case 1:
                DisplayDaysUntilGradiation = $" (færdig om {DaysUntilGraduation} dag)";
                break;
            case > 1:
                DisplayDaysUntilGradiation = $" (færdig om {DaysUntilGraduation} dage)";
                break;
            default:
                DisplayDaysUntilGradiation = null;
                break;
        }
    }
}
