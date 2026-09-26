using System.Text.Json.Serialization;

namespace ZealandPortfolioLib.Models;

public class Comment
{
	/// <summary>
	/// The unique identifier for the comment.
	/// </summary>
	[JsonPropertyName("id")]
    public Guid Id { get; init; }

	/// <summary>
	/// The author of the comment.
	/// </summary>
	[JsonPropertyName("author")]
	public required string Author { get; init; }

	/// <summary>
	/// The message of the comment.
	/// </summary>
	[JsonPropertyName("message")]
	public required string Message { get; init; }

	/// <summary>
	/// The date and time the comment was created.
	/// </summary>
	[JsonPropertyName("created_at")]
	public required DateTime CreatedAt { get; init; }

	/// <summary>
	/// Initializes a new instance of the <see cref="Comment"/> class with a new unique identifier.
	/// </summary>
	public Comment()
	{
		Id = Guid.NewGuid();
	}
	public override string ToString()
	{
		return $"Comment: Id: {Id}, Author: {Author}, Message: {Message}, CreatedAt: {CreatedAt}";
	}

	/// <summary>
	/// Gets the initial character of the author's name, converted to uppercase. If the author's name is null or empty, returns a question mark `?`.
	/// </summary>
	/// <returns></returns>
	public char GetInitial()
	{
		if (!string.IsNullOrEmpty(Author))
		{
			return Author[0];
		}
		return '?';
	}

	/// <summary>
	/// Returns a human-readable string representing the relative time elapsed since the comment was created.
	/// </summary>
	/// <returns>A string representing the relative time elapsed.</returns>
	public string TimeAgo()
	{
		return TimeFormatter.FormatRelativeTime(CreatedAt);
	}
}
