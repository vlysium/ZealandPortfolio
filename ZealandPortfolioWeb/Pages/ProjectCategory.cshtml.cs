using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandPortfolioLib;
using ZealandPortfolioLib.Services;

namespace ZealandPortfolioWeb.Pages
{
    public class ProjectCategoryModel : PageModel
    {
        /// <summary>
        /// The service for accessing project categories.
        /// </summary>
        private readonly ProjectCategoryService _projectCategoryService;

        /// <summary>
        /// The project category with its associated projects.
        /// </summary>
        public required ProjectCategoryWithProjects ProjectCategory { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectCategoryModel"/> class with the specified project category service.
        /// </summary>
        /// <param name="projectCategoryService">The project category service to use.</param>
        public ProjectCategoryModel(ProjectCategoryService projectCategoryService)
        {
            _projectCategoryService = projectCategoryService;
        }

        public IActionResult OnGet(string category)
        {
            try
            {
                ProjectCategory = _projectCategoryService.GetProjectCategoryWithProjectsBySlug(category);
                ProjectCategory.Projects.Sort((p1, p2) => p2.TimeStamp.CompareTo(p1.TimeStamp)); // Sort projects by TimeStamp in descending order
                return Page();
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine($"Error retrieving project category with slug '{category}': {ex.Message}");
                return RedirectToPage("/Index");
            }
        }
    }
}
