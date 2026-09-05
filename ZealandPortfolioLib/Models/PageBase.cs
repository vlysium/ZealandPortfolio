using System;

namespace ZealandPortfolioLib.Models;

public abstract class PageBase
{
	/// <summary>
	/// The unique identifier for the page.
	/// </summary>
	public required Guid Id { get; init; }

	/// <summary>
	/// Name of the page.
	/// </summary>
	public required string Name { get; init; }

	/// <summary>
	/// Description of the page.
	/// </summary>
	public required string Description { get; init; }

	/// <summary>
	/// Slug of the page.
	/// </summary>
	public required string Slug { get; init; }

	/// <summary>
	/// Image associated with the page.
	/// </summary>
	public required Image Image { get; init; }

	/// <summary>
	/// Initializes a new instance of the <see cref="PageBase"/> class.
	/// </summary>
	public PageBase() { }

	public override string ToString()
	{
		return $"PageBase: Id: {Id}, Name: {Name}, Description: {Description}, Slug: {Slug}, Image: {Image}";
	}
}
