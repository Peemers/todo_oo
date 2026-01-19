using To_Do.Data;
using To_Do.Repositories.Interfaces;

namespace To_Do.Repositories.Implementations;

public class TacheRepository : ITacheRepository
{
  private readonly DataContext _context;
}