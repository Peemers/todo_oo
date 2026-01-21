using System.Collections.Immutable;
using System.Net;
using Microsoft.EntityFrameworkCore;
using To_Do.Data;
using To_Do.Models;
using To_Do.UI;
using Microsoft.AspNetCore.Builder;

namespace To_Do;

internal class Program
{
  static void Main(string[] args)
  {
    var builder = .CreateBuilder(args);
    
    using var context = new DataContext();
    
    context.Database.Migrate();

    var liste = context.ListeDeTaches
      .Include(l => l.Taches)
      .FirstOrDefault();

    if (liste == null)
    {
      liste = new ListeDeTaches();
      context.ListeDeTaches.Add(liste);
      context.SaveChanges();
    }

    var ui = new ConsoleUI(liste);

    while (true)
    {
      ui.Run();
      context.SaveChanges();
      break;
    }
  }
}