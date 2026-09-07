using System.Text.Json.Serialization;

namespace ZealandPortfolioLib.Models;

public abstract class PageBase
{
	/// <summary>
	/// The unique identifier for the page.
	/// </summary>
	[JsonPropertyName("id")]
	public required Guid Id { get; init; }

	/// <summary>
	/// Name of the page.
	/// </summary>
	[JsonPropertyName("name")]
	public required string Name { get; init; }

	/// <summary>
	/// Description of the page.
	/// </summary>
	[JsonPropertyName("description")]
	public required List<string> Description { get; init; }

	/// <summary>
	/// Slug of the page.
	/// </summary>
	[JsonPropertyName("slug")]
	public required string Slug { get; init; }

	/// <summary>
	/// Image associated with the page.
	/// </summary>
	[JsonPropertyName("image")]
	public required Image Image { get; init; }

	/// <summary>
	/// Initializes a new instance of the <see cref="PageBase"/> class.
	/// </summary>
	public PageBase() { }

	public override string ToString()
	{
		return $"PageBase: Id: {Id}, Name: {Name}, Description: {Description}, Slug: {Slug}, Image: {Image}";
	}

	/// <summary>
	/// Gets the inline description of the project by joining the description list into a single string.
	/// </summary>
	/// <returns>The inline description of the project.</returns>
	public string GetInlineDescription()
	{
		return string.Join(" ", Description);
	}
}
