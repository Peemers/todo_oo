using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using To_Do.Models;

namespace To_Do.Configurations
{
    internal class ListeDeTachesConfiguration : IEntityTypeConfiguration<ListeDeTaches>
    {
        public void Configure(EntityTypeBuilder<ListeDeTaches> builder)
        {
            
            builder.HasKey(l => l.Id);           
                     
            builder.HasMany(l => l.Taches)
                   .WithOne(t => t.ListeDeTaches)
                   .HasForeignKey(t => t.ListeDeTachesId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
