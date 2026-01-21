using Microsoft.EntityFrameworkCore;
using To_Do.Data;
using To_Do.Models;
using To_Do.Repositories.Interfaces;

namespace To_Do.Repositories.Implementations;

public class ListeDeTachesRepository : IListeDeTachesRepository
{
  private readonly DataContext _context;

  public ListeDeTachesRepository(DataContext context)
  {
    _context = context;
  }

  public async Task AddAsync(ListeDeTaches liste)
  {
    await _context.ListeDeTaches.AddAsync(liste);
  }

  public async Task<IEnumerable<ListeDeTaches>> GetAllAsync()
  {
    return await _context.ListeDeTaches.ToListAsync();
  }

  public async Task<ListeDeTaches?> GetByIdAsync(int id)
  {
    return await _context.ListeDeTaches.FindAsync(id);
  }

  public async Task DeleteAsyncById(int id)
  {
    var liste = await _context.ListeDeTaches.FindAsync(id);
    if (liste == null)
      return;

    _context.ListeDeTaches.Remove(liste);
  }
}