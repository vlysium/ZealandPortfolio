using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandPortfolioLib;
using ZealandPortfolioLib.Models;

namespace ZealandPortfolioWeb.Pages
{
    public class ProjectPageModel : PageModel
    {
        /// <summary>
        /// The service for accessing projects.
        /// </summary>
        private readonly ProjectService _projectService;

        /// <summary>
        /// The project to be displayed on the page.
        /// </summary>
        public required Project Project { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectPageModel"/> class with the specified project service.
        /// </summary>
        /// <param name="projectService">The project service to use.</param>
        public ProjectPageModel(ProjectService projectService)
        {
            _projectService = projectService;
        }
        
        public IActionResult OnGet(string category, string slug)
        {
            try
            {
                Project = _projectService.GetProjectBySlug(slug);

                // Ensure that the project belongs to the specified category
                if (Project.Category != category)
                {
                    throw new KeyNotFoundException($"The project with slug '{slug}' does not belong to the category '{category}'.");
                }

                return Page();
            }
            catch (KeyNotFoundException)
            {
                // Console.WriteLine($"Error retrieving project with slug '{slug}': {ex.Message}");
                return NotFound();
            }
        }
    }
}
