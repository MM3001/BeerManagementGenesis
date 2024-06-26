using BeerManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerManagement.Database.Mapping
{
    public class BeerConfiguration : IEntityTypeConfiguration<Beer>
    {
        public void Configure(EntityTypeBuilder<Beer> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).HasMaxLength(50).IsRequired();
            builder.Property(b => b.Price).IsRequired();
            builder.Property(b => b.AlcoholLevel).IsRequired();
        }
    }
}
