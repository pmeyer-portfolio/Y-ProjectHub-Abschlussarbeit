namespace ProjectHub.Data.Abstractions.IRepositories;

public interface IGenericRepository<T> where T : class
{
    Task AddAsync(T entity);

    Task<T?> GetByIdAsync(int id);

    Task<IList<T>> GetAllAsync();

    bool Exists(T entity);

    Task UpdateAsync(T entity);
}