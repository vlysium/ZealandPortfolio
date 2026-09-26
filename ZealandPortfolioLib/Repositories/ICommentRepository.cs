using System;
using ZealandPortfolioLib.Models;

namespace ZealandPortfolioLib.Repositories;

public interface ICommentRepository
{
	public List<Comment> ReadAll();
	public Comment ReadById(Guid id);
	public void Create(Comment comment);
}
