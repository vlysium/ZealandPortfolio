using ZealandPortfolioLib.Models;

namespace ZealandPortfolioLib;

public class ProjectCategory : PageBase
{
	/// <summary>
	/// List of project IDs belonging to the project category.
	/// </summary>
	public required List<Guid> ProjectIds { get; init; } = new List<Guid>();

	/// <summary>
	/// Initializes a new instance of the <see cref="ProjectCategory"/> class.
	/// </summary>
	public ProjectCategory() { }

	public override string ToString()
	{
		return base.ToString() + $", Projects: [{string.Join(", ", ProjectIds)}]";
	}
}
