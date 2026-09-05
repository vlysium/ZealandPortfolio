using ZealandPortfolioLib.Models;

namespace ZealandPortfolioLib;

public class ProjectCategory : PageBase
{
	/// <summary>
	/// List of projects belonging to the project category.
	/// </summary>
	public required List<Project> Projects { get; init; } = new List<Project>();

	/// <summary>
	/// Initializes a new instance of the <see cref="ProjectCategory"/> class.
	/// </summary>
	public ProjectCategory() { }

	public override string ToString()
	{
		return base.ToString() + $", Projects: [{string.Join(", ", Projects)}]";
	}
}
