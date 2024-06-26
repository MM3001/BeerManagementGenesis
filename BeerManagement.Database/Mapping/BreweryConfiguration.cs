using BeerManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerManagement.Database.Mapping
{
    public class BreweryConfiguration : IEntityTypeConfiguration<Brewery>
    {
        public void Configure(EntityTypeBuilder<Brewery> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).HasMaxLength(50).IsRequired();

            builder.HasMany(b => b.Beers)
                .WithOne()
                .HasForeignKey(b => b.BreweryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
