using Microsoft.EntityFrameworkCore;
using To_Do.Models;

namespace To_Do.Data;

public class DataContext : DbContext
{
  public DbSet<Tache> Taches { get; set; }
  public DbSet<ListeDeTaches> ListeDeTaches { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      string connectionString =
        @"Server=itareapeemers;
        User Id=sa;
        Password=***; //mdp caché ne pas oublié de le remettre en attendant la bonne sécu
        Database=To_DoDB;
        Trust Server Certificate=True";

      optionsBuilder.UseSqlServer(connectionString);
    }

    base.OnConfiguring(optionsBuilder);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Tache>()
      .Property(t => t.Titre)
      .IsRequired();

    modelBuilder.Entity<Tache>()
      .Property(t => t.Description)
      .IsRequired(false);

    modelBuilder.Entity<ListeDeTaches>()
      .HasMany(l => l.Taches)
      .WithOne(t => t.ListeDeTaches)
      .HasForeignKey(t => t.ListeDeTachesId)
      .OnDelete(DeleteBehavior.Cascade);

    base.OnModelCreating(modelBuilder);
  }
}