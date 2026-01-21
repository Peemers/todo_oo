namespace To_Do.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
  Task AddAsync(T t);
  Task<IEnumerable<T>> GetAllAsync();
  Task<T?> GetByIdAsync(int id);
  Task DeleteAsyncById(int id);
}