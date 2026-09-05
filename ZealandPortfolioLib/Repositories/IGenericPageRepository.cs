namespace ZealandPortfolioLib;

public interface IGenericPageRepository<T>
{
	public List<T> ReadAll();
	public T ReadById(string id);
	// public void Create(T page);
	// public void Update(T page);
	// public void Delete(T page);
}
