using System.Text.Json.Serialization;

namespace ZealandPortfolioLib.Models;

public class Image
{
	/// <summary>
	/// Source URL of the image.
	/// </summary>
	[JsonPropertyName("src")]
	public required string Src { get; init; }
	
	/// <summary>
	/// Alternative text for the image.
	/// </summary>
	[JsonPropertyName("alt_text")]
	public required string AltText { get; init; }

	/// <summary>
	/// Initializes a new instance of the <see cref="Image"/> class.
	/// </summary>
	public Image() { }

	public override string ToString()
	{
		return $"Image: {Src}, AltText: {AltText}";
	}
}
