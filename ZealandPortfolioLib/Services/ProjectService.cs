using ZealandPortfolioLib.Models;

namespace ZealandPortfolioLib;

public class ProjectService
{
	private readonly IGenericPageRepository<Project> _projectRepository;

	/// <summary>
	/// Initializes a new instance of the <see cref="ProjectService"/> class.
	/// </summary>
	/// <param name="projectRepository">The repository to use for accessing project data.</param>
	public ProjectService(IGenericPageRepository<Project> projectRepository)
	{
		_projectRepository = projectRepository;
	}

	/// <summary>
	/// Gets a project by its id.
	/// </summary>
	/// <param name="id">The id of the project to get.</param>
	/// <returns>The project with the specified id.</returns>
	public Project GetProjectById(Guid id)
	{
		return _projectRepository.ReadById(id);
	}
}
