

namespace To_Do.Repositories.Interfaces;

internal interface IListeDeTacheRepository<T> : IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllTachesAsync();
}
