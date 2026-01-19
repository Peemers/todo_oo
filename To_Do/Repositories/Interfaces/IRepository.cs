namespace To_Do.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    Task addAsync(T t);
    Task<IEnumerable<T>> Getall();
    Task<T?> GetByIdAsync(int id);
    Task DeleteAsync(int id);
}
