using ZealandPortfolioLib.Models;

namespace ZealandPortfolioLib;

public class ProjectCategory : PageBase
{
	/// <summary>
	/// List of project IDs belonging to the project category.
	/// </summary>
	public required List<string> ProjectIds { get; init; } = new List<string>();

	/// <summary>
	/// Initializes a new instance of the <see cref="ProjectCategory"/> class.
	/// </summary>
	public ProjectCategory() { }

	public override string ToString()
	{
		return base.ToString() + $", Projects: [{string.Join(", ", ProjectIds)}]";
	}
}
