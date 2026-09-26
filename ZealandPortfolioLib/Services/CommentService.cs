using System;
using ZealandPortfolioLib.Models;
using ZealandPortfolioLib.Repositories;

namespace ZealandPortfolioLib.Services;

public class CommentService
{
	private readonly ICommentRepository _commentRepository;

	/// <summary>
	/// Initializes a new instance of the <see cref="CommentService"/> class.
	/// </summary>
	/// <param name="commentRepository">The repository to use for comment operations.</param>
	public CommentService(ICommentRepository commentRepository)
	{
		_commentRepository = commentRepository;
	}

	/// <summary>
	/// Gets all comments from the repository.
	/// </summary>
	/// <returns>A list of all comments in the repository.</returns>
	public List<Comment> GetAllComments()
	{
		return _commentRepository.ReadAll();
	}

	/// <summary>
	/// Gets a comment by its id from the repository.
	/// </summary>
	/// <param name="id">The id of the comment to get.</param>
	/// <returns>The comment with the specified id.</returns>
	public Comment GetCommentById(Guid id)
	{
		return _commentRepository.ReadById(id);
	}

	/// <summary>
	/// Creates a new comment and adds it to the repository.
	/// </summary>
	/// <param name="comment">The comment to create.</param>
	public void CreateComment(Comment comment)
	{
		_commentRepository.Create(comment);
	}

	/// <summary>
	/// Gets the last N comments from the repository, ordered by creation date in descending order.
	/// </summary>
	/// <param name="n">The number of comments to retrieve.</param>
	/// <returns>A list of the last N comments in the repository.</returns>
	public List<Comment> GetLastNComments(int n)
	{
		return _commentRepository.ReadAll().OrderByDescending(c => c.CreatedAt).Take(n).ToList();
	}
}
