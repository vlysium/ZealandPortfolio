using System;
using System.Text.Json;
using ZealandPortfolioLib.Models;

namespace ZealandPortfolioLib.Repositories;

public class CommentRepository : ICommentRepository
{
	/// <summary>
	/// The name of the file that contains the comments data.
	/// </summary>
	private readonly string _fileName;

	/// <summary>
	/// The list that holds the comments stored in memory.
	/// </summary>
	private List<Comment> _comments = new List<Comment>();

	/// <summary>
	/// Initializes a new instance of the <see cref="CommentRepository"/> class.
	/// </summary>
	/// <exception cref="FileNotFoundException">Thrown when the specified file is not found.</exception>
	/// <exception cref="InvalidOperationException">Thrown when the file is empty or does not contain valid JSON.</exception>
	public CommentRepository()
	{
		_fileName = "Comment.json";

		string path = Path.Combine("PersistentData", _fileName);
		if (!File.Exists(path))
		{
			throw new FileNotFoundException($"The file \"{_fileName}\" was not found in the \"PersistentData\" folder.");
		}

		string json = File.ReadAllText(path);
		if (string.IsNullOrWhiteSpace(json))
		{
			throw new InvalidOperationException($"The file \"{_fileName}\" is empty or does not contain valid JSON.");
		}

		_comments = JsonSerializer.Deserialize<List<Comment>>(json)
			?? throw new InvalidOperationException($"The file \"{_fileName}\" does not contain valid JSON for the type \"{typeof(Comment).Name}\".");
	}

	/// <summary>
	/// Creates a new comment, adds it to the repository, and saves the updated list to the file.
	/// </summary>
	/// <param name="comment">The comment to create.</param>
	public void Create(Comment comment)
	{
		_comments.Add(comment);
		string json = JsonSerializer.Serialize(_comments, new JsonSerializerOptions { WriteIndented = true });
		File.WriteAllText(Path.Combine("PersistentData", _fileName), json);
	}

	/// <summary>
	/// Reads all comments from the repository.
	/// </summary>
	/// <returns>A list of all comments in the repository.</returns>
	public List<Comment> ReadAll()
	{
		return _comments;
	}

	/// <summary>
	/// Reads a comment from the repository by its id.
	/// </summary>
	/// <param name="id">The id of the comment to read.</param>
	/// <returns>The comment with the specified id.</returns>
	/// <exception cref="KeyNotFoundException">Thrown when no comment is found with the specified id.</exception>
	public Comment ReadById(Guid id)
	{
		return _comments.FirstOrDefault(c => c.Id == id)
			?? throw new KeyNotFoundException($"No comment found with the specified id: {id}");
	}
}
