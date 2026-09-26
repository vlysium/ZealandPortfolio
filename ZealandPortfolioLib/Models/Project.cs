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
	/// Description of the project.
	/// </summary>
	[JsonPropertyName("description_long")]
	public required List<string> DescriptionLong { get; init; }

	/// <summary>
	/// The category the project belongs to.
	/// </summary>
	[JsonPropertyName("category")]
	public required string Category { get; init; }

	/// <summary>
	/// Github link associated with the project.
	/// </summary>
	[JsonPropertyName("github_link")]
	public required string? GithubLink { get; init; }

	/// <summary>
	/// Website link associated with the project.
	/// </summary>
	[JsonPropertyName("website_link")]
	public required string? WebsiteLink { get; init; }

	/// <summary>
	/// The date and time when the project was created or submitted.
	/// </summary>
	[JsonPropertyName("time_stamp")]
	public required DateTime TimeStamp { get; init; }

	/// <summary>
	/// Initializes a new instance of the <see cref="Project"/> class.
	/// </summary>
	public Project() { }

	public override string ToString()
	{
		return base.ToString() + $", DescriptionShort: {DescriptionShort}, Category: {Category}, GithubLink: {GithubLink}, WebsiteLink: {WebsiteLink}, TimeStamp: {TimeStamp}";
	}

	/// <summary>
	/// Returns a human-readable string representing the relative time elapsed since the project was created or submitted.
	/// </summary>
	/// <returns>A string representing the relative time elapsed.</returns>
	public string TimeAgo()
	{
		return TimeFormatter.FormatRelativeTime(TimeStamp);
	}
}
