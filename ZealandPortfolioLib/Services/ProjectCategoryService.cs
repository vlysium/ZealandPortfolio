using ZealandPortfolioLib.Models;

namespace ZealandPortfolioLib.Services;

public class ProjectCategoryService
{
	private readonly IGenericPageRepository<ProjectCategory> _projectCategoryRepository;
	private readonly IGenericPageRepository<Project> _projectRepository;

	/// <summary>
	/// Initializes a new instance of the <see cref="ProjectCategoryService"/> class.
	/// </summary>
	/// <param name="projectCategoryRepository">The repository to use for accessing project category data.</param>
	/// <param name="projectRepository">The repository to use for accessing project data.</param>
	public ProjectCategoryService(IGenericPageRepository<ProjectCategory> projectCategoryRepository, IGenericPageRepository<Project> projectRepository)
	{
		_projectCategoryRepository = projectCategoryRepository;
		_projectRepository = projectRepository;
	}

	/// <summary>
	/// Gets all project categories.
	/// </summary>
	/// <returns>The list of all project categories.</returns>
	public List<ProjectCategory> GetAllProjectCategories()
	{
		return _projectCategoryRepository.ReadAll();
	}

	/// <summary>
	/// Gets a project category by its id.
	/// </summary>
	/// <param name="id">The id of the project category to get.</param>
	/// <returns>The project category with the specified id.</returns>
	public ProjectCategory GetProjectCategoryById(Guid id)
	{
		return _projectCategoryRepository.ReadById(id);
	}

	/// <summary>
	/// Gets a project category with its associated projects by its slug.
	/// </summary>
	/// <param name="slug">The slug of the project category to get.</param>
	/// <returns>The project category with the specified slug and its associated projects.</returns>
	public ProjectCategoryWithProjects GetProjectCategoryWithProjectsBySlug(string slug)
	{
		ProjectCategory projectCategory = _projectCategoryRepository.ReadBySlug(slug);
		ProjectCategoryWithProjects projectCategoryWithProjects = new ProjectCategoryWithProjects
		{
			Id = projectCategory.Id,
			Name = projectCategory.Name,
			Description = projectCategory.Description,
			Slug = projectCategory.Slug,
			Image = projectCategory.Image,
			Projects = PopulateProjects(projectCategory)
		};

		return projectCategoryWithProjects;
	}

	/// <summary>
	/// A helper method to populate the Projects property of a ProjectCategory with the actual Project objects based on their IDs.
	/// </summary>
	/// <param name="projectCategory">The project category to populate the projects for.</param>
	/// <returns>The list of projects for the specified project category.</returns>
	private List<Project> PopulateProjects(ProjectCategory projectCategory)
	{
		return projectCategory.ProjectIds.Select(_projectRepository.ReadById).ToList();
	}
}
