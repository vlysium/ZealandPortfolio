using System.Text.Json;
using ZealandPortfolioLib.Models;

namespace ZealandPortfolioLib.Repositories;

public class GenericPageRepository<T> : IGenericPageRepository<T> where T : PageBase
{
	/// <summary>
	/// The list of pages stored in memory. This list is populated from a JSON file during the initialization of the repository.
	/// </summary>
	private List<T> _pages = new List<T>();

	/// <summary>
	/// Initializes a new instance of the <see cref="GenericPageRepository{T}"/> class.
	/// </summary>
	/// <param name="fileName">Name of the file to read the pages from.</param>
	/// <exception cref="FileNotFoundException">Thrown when the specified file is not found.</exception>
	/// <exception cref="InvalidOperationException">Thrown when the file is empty or does not contain valid JSON.</exception>
	public GenericPageRepository(string fileName)
	{
		string path = Path.Combine("Data", fileName);
		string json = File.ReadAllText(path);

		if (!File.Exists(path))
		{
			throw new FileNotFoundException($"The file \"{fileName}\" was not found in the \"Data\" folder.");
		}

		if (string.IsNullOrWhiteSpace(json))
		{
			throw new InvalidOperationException($"The file \"{fileName}\" is empty or does not contain valid JSON.");
		}

		_pages = JsonSerializer.Deserialize<List<T>>(json)
			?? throw new InvalidOperationException($"The file \"{fileName}\" does not contain valid JSON for the type \"{typeof(T).Name}\".");
	}

	/// <summary>
	/// Reads all pages from the repository.
	/// </summary>
	/// <returns>A list of all pages in the repository.</returns>
	public List<T> ReadAll()
	{
		return _pages;
	}

	/// <summary>
	/// Reads a page from the repository by its id.
	/// </summary>
	/// <param name="id">The id of the page to read.</param>
	/// <returns>The page with the specified id.</returns>
	/// <exception cref="KeyNotFoundException">Thrown when no page is found with the specified id.</exception>
	public T ReadById(string id)
	{
		return _pages.FirstOrDefault(page => page.Id == id)
			?? throw new KeyNotFoundException($"No page found with the id \"{id}\".");
	}
}
