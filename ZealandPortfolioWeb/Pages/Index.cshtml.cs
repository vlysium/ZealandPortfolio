using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandPortfolioLib;
using ZealandPortfolioLib.Models;
using ZealandPortfolioLib.Services;

namespace ZealandPortfolioWeb.Pages;

public class IndexModel : PageModel
{
    /// <summary>
    /// The service for accessing project categories.
    /// </summary>
    private readonly ProjectCategoryService _projectCategoryService;

    /// <summary>
    /// The service for handling comments.
    /// </summary>
    private readonly CommentService _commentService;

    /// <summary>
    /// Gets or sets the list of project categories to be displayed on the index page.
    /// </summary>
    public List<ProjectCategory> ProjectCategories { get; set; } = new List<ProjectCategory>();

    /// <summary>
    /// Gets or sets the list of the latest 10 comments to be displayed on the index page.
    /// </summary>
    public List<Comment> Latest10Comments { get; set; } = new List<Comment>();

    /// <summary>
    /// Gets or sets the display text for the number of days until graduation.
    /// </summary>
    public string? DisplayDaysUntilGradiation { get; set; }

    /// <summary>
    /// Gets or sets the number of years of age.
    /// </summary>
    public string YearsOfAge { get; init; } = Math.Floor((DateTime.Now - new DateTime(2000, 12, 23)).TotalDays / 365.25).ToString();

    /// <summary>
    /// Gets or sets the user comment to be submitted through the form on the index page.
    /// </summary>
    [BindProperty]
    public required Comment UserComment { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="IndexModel"/> class with the specified project category service.
    /// </summary>
    /// <param name="projectCategoryService">The project category service to use.</param>
    /// <param name="commentService">The comment service to use.</param>
    public IndexModel(ProjectCategoryService projectCategoryService, CommentService commentService)
    {
        _projectCategoryService = projectCategoryService;
        _commentService = commentService;
    }

    public void OnGet()
    {
        ProjectCategories = _projectCategoryService.GetAllProjectCategories();
        Latest10Comments = _commentService.GetLastNComments(10);

        int DaysUntilGraduation = new DateTime(2028, 6, 30).Subtract(DateTime.Today).Days;
        switch (DaysUntilGraduation)
        {
            case 1:
                DisplayDaysUntilGradiation = $" (færdig om ~{DaysUntilGraduation} dag)";
                break;
            case > 1:
                DisplayDaysUntilGradiation = $" (færdig om ~{DaysUntilGraduation} dage)";
                break;
            default:
                DisplayDaysUntilGradiation = null;
                break;
        }
    }

    public IActionResult OnPost()
    {
        try
        {
            DateTime curentDateTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Central European Standard Time");

            if (string.IsNullOrWhiteSpace(UserComment.Author) || string.IsNullOrWhiteSpace(UserComment.Message) || UserComment.Author.Length < 1 || UserComment.Message.Length < 1)
            {
                throw new ArgumentException("Navn og besked kan ikke være tomme.");
            }

            if (UserComment.Author.Length > 20 || UserComment.Message.Length > 200)
            {
                throw new ArgumentException("Navn kan ikke være længere end 20 tegn og besked kan ikke være længere end 200 tegn.");
            }

            Comment newComment = new Comment
            {
                Author = UserComment.Author.Trim(),
                Message = UserComment.Message.Trim(),
                CreatedAt = curentDateTime
            };

            _commentService.CreateComment(newComment);

            return RedirectToPage();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
