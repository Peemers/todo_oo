namespace To_Do.Repositories.Interfaces;

internal interface IRepository<T> where T : class
{
    Task addAsync(T t);
    Task<IEnumerable<T>> Getall();
    Task<T?> GetByIdAsync(int id);
    Task DeleteAsync(int id);
}
