using System.Text.Json;
using ZealandPortfolioLib.Models;

namespace ZealandPortfolioLib.Repositories;

public class GenericPageRepository<T> : IGenericPageRepository<T> where T : PageBase
{
	/// <summary>
	/// The dictionary that holds the pages stored in memory, with the page ID as the key and the page object as the value.
	/// </summary>
	private Dictionary<string, T> _pages = new Dictionary<string, T>();

	/// <summary>
	/// Initializes a new instance of the <see cref="GenericPageRepository{T}"/> class.
	/// </summary>
	/// <param name="fileName">Name of the file to read the pages from.</param>
	/// <exception cref="FileNotFoundException">Thrown when the specified file is not found.</exception>
	/// <exception cref="InvalidOperationException">Thrown when the file is empty or does not contain valid JSON.</exception>
	public GenericPageRepository(string fileName)
	{
		string path = Path.Combine("Data", fileName);
		if (!File.Exists(path))
		{
			throw new FileNotFoundException($"The file \"{fileName}\" was not found in the \"Data\" folder.");
		}

		string json = File.ReadAllText(path);
		if (string.IsNullOrWhiteSpace(json))
		{
			throw new InvalidOperationException($"The file \"{fileName}\" is empty or does not contain valid JSON.");
		}

		_pages = JsonSerializer.Deserialize<List<T>>(json)?.ToDictionary(page => page.Id)
			?? throw new InvalidOperationException($"The file \"{fileName}\" does not contain valid JSON for the type \"{typeof(T).Name}\".");
	}

	/// <summary>
	/// Reads all pages from the repository.
	/// </summary>
	/// <returns>A list of all pages in the repository.</returns>
	public List<T> ReadAll()
	{
		return _pages.Values.ToList();
	}

	/// <summary>
	/// Reads a page from the repository by its id.
	/// </summary>
	/// <param name="id">The id of the page to read.</param>
	/// <returns>The page with the specified id.</returns>
	/// <exception cref="KeyNotFoundException">Thrown when no page is found with the specified id.</exception>
	public T ReadById(string id)
	{
		return _pages.TryGetValue(id, out T? page)
        ? page
        : throw new KeyNotFoundException(
            $"No page found with the id \"{id}\".");
	}
}
