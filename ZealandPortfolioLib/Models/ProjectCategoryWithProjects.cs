using System.Text.Json.Serialization;
using ZealandPortfolioLib.Models;

namespace ZealandPortfolioLib;

public class ProjectCategoryWithProjects : PageBase
{
	/// <summary>
	/// List of projects belonging to the project category.
	/// </summary>
	[JsonPropertyName("projects")]
	public required List<Project> Projects { get; set; } = new List<Project>();

	/// <summary>
	/// Initializes a new instance of the <see cref="ProjectCategoryWithProjects"/> class.
	/// </summary>
	public ProjectCategoryWithProjects() { }

	public override string ToString()
	{
		return base.ToString() + $", Projects: [{string.Join(", ", Projects)}]";
	}
}
