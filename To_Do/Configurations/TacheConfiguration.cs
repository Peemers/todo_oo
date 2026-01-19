using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using To_Do.Models;

namespace To_Do.Configurations
{
    internal class TacheConfiguration : IEntityTypeConfiguration<Tache>
    {
        public void Configure(EntityTypeBuilder<Tache> builder)
        {
            
            builder.HasKey(t => t.Id);

            
            builder.Property(t => t.Titre)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(t => t.Description)
                   .HasMaxLength(500)
                   .IsRequired(false);

            
            builder.HasOne(t => t.ListeDeTaches)
                   .WithMany(l => l.Taches)
                   .HasForeignKey(t => t.ListeDeTachesId);
        }
    }
}

