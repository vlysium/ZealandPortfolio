using System.Text.Json.Serialization;

namespace ZealandPortfolioLib.Models;

public class Link
{
	/// <summary>
	/// Href of the link.
	/// </summary>
	[JsonPropertyName("href")]
	public required string Href { get; init; }

	/// <summary>
	/// Text of the link.
	/// </summary>
	[JsonPropertyName("text")]
	public required string Text { get; init; }

	/// <summary>
	/// Initializes a new instance of the <see cref="Link"/> class.
	/// </summary>
	public Link() { }

	public override string ToString()
	{
		return $"Link: Href: {Href}, Text: {Text}";
	}
}
