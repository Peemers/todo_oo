using To_Do.Repositories.Interfaces;
using To_Do.Data;
using Microsoft.EntityFrameworkCore;

namespace To_Do.Repositories.Implementations;

public abstract class Repository<T> : IRepository<T> where T : class
{
    
    public abstract async Task AddAsync(T entity);
     
}
