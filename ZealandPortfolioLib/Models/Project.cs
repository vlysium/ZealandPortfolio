using System.Text.Json.Serialization;

namespace ZealandPortfolioLib.Models;

public class Project : PageBase
{
	/// <summary>
	/// Short description of the project.
	/// </summary>
	[JsonPropertyName("description_short")]
	public required string DescriptionShort { get; init; }

	/// <summary>
	/// Github link associated with the project.
	/// </summary>
	[JsonPropertyName("github_link")]
	public required string GithubLink { get; init; }

	/// <summary>
	/// Website link associated with the project.
	/// </summary>
	[JsonPropertyName("website_link")]
	public required string WebsiteLink { get; init; }

	/// <summary>
	/// Initializes a new instance of the <see cref="Project"/> class.
	/// </summary>
	public Project() { }

	public override string ToString()
	{
		return base.ToString() + $", DescriptionShort: {DescriptionShort}, GithubLink: {GithubLink}, WebsiteLink: {WebsiteLink}";
	}
}
