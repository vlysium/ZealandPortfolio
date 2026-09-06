using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandPortfolioLib;

namespace ZealandPortfolioWeb.Pages;

public class IndexModel : PageModel
{
    /// <summary>
    /// The repository for accessing project categories.
    /// </summary>
    private readonly IGenericPageRepository<ProjectCategory> _projectCategoryRepository;

    /// <summary>
    /// Gets or sets the list of project categories to be displayed on the index page.
    /// </summary>
    public List<ProjectCategory> ProjectCategories { get; set; } = new List<ProjectCategory>();

    /// <summary>
    /// Initializes a new instance of the <see cref="IndexModel"/> class with the specified project category repository.
    /// </summary>
    /// <param name="projectCategoryRepository">The project category repository to use.</param>
    public IndexModel(IGenericPageRepository<ProjectCategory> projectCategoryRepository)
    {
        _projectCategoryRepository = projectCategoryRepository;
    }

    public void OnGet()
    {
        ProjectCategories = _projectCategoryRepository.ReadAll();
    }
}
