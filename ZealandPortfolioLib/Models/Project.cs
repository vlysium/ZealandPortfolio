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
		return base.ToString() + $", DescriptionShort: {DescriptionShort}, GithubLink: {GithubLink}, WebsiteLink: {WebsiteLink}, TimeStamp: {TimeStamp}";
	}

	/// <summary>
	/// Returns a human-readable string representing the time elapsed since the project was created or submitted.
	/// </summary>
	/// <returns>A string representing the time elapsed. </returns>
	public string TimeAgo()
	{
		TimeSpan elapsed = DateTime.Now - TimeStamp;

		if (elapsed.TotalSeconds < 60)
		{
			int seconds = (int)elapsed.TotalSeconds;
			return $"{seconds} {(seconds == 1 ? "sekund" : "sekunder")} siden";
		}

		if (elapsed.TotalMinutes < 60)
		{
			int minutes = (int)elapsed.TotalMinutes;
			return $"{minutes} {(minutes == 1 ? "minut" : "minutter")} siden";
		}

		if (elapsed.TotalHours < 24)
		{
			int hours = (int)elapsed.TotalHours;
			return $"{hours} {(hours == 1 ? "time" : "timer")} siden";
		}

		if (elapsed.TotalDays < 7)
		{
			int days = (int)elapsed.TotalDays;
			return $"{days} {(days == 1 ? "dag" : "dage")} siden";
		}

		if (elapsed.TotalDays < 30)
		{
			int weeks = (int)(elapsed.TotalDays / 7);
			return $"{weeks} {(weeks == 1 ? "uge" : "uger")} siden";
		}

		if (elapsed.TotalDays < 365)
		{
			int months = (int)(elapsed.TotalDays / 30);
			return $"{months} {(months == 1 ? "måned" : "måneder")} siden";
		}

		int years = (int)(elapsed.TotalDays / 365);
		return $"{years} {(years == 1 ? "år" : "år")} siden";
	}
}
