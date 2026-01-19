namespace To_Do.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
  Task AddAsync(T t);
  Task<IEnumerable<T>> GetAll();
  Task<T?> GetByIdAsync(int id);
  Task DeleteAsync(int id);
}