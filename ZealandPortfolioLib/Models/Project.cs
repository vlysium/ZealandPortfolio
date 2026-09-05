namespace ZealandPortfolioLib.Models;

public class Project : PageBase
{
	/// <summary>
	/// Github link associated with the project.
	/// </summary>
	public required Link GithubLink { get; init; }

	/// <summary>
	/// Live link associated with the project.
	/// </summary>
	public required Link LiveLink { get; init; }

	/// <summary>
	/// Initializes a new instance of the <see cref="Project"/> class.
	/// </summary>
	public Project() { }

	public override string ToString()
	{
		return base.ToString() + $", GithubLink: {GithubLink}, LiveLink: {LiveLink}";
	}
}
