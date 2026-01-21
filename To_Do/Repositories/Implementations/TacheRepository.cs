using Microsoft.EntityFrameworkCore;
using To_Do.Data;
using To_Do.Models;
using To_Do.Repositories.Interfaces;

namespace To_Do.Repositories.Implementations;

internal class TacheRepository : ITacheRepository
{
  protected readonly DataContext _context;

  public TacheRepository(DataContext context)
  {
    _context = context;
  }

  public async Task AddAsync(Tache t)
  {
    await _context.Taches.AddAsync(t);
  }

  public async Task<IEnumerable<Tache>> GetAllAsync()
  {
    return await _context.Taches.ToListAsync();
  }

  public async Task<Tache?> GetByIdAsync(int id)
  {
    return await _context.Taches.FindAsync(id);
  }

  public async Task DeleteAsyncById(int id)
  {
    var tache = await _context.Taches.FindAsync(id);
    if (tache == null)
      return;

    _context.Taches.Remove(tache);
  }
}