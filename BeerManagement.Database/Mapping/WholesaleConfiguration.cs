using BeerManagement.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BeerManagement.Database.Mapping
{
    public class WholesaleConfiguration : IEntityTypeConfiguration<Wholesaler>
    {
        public void Configure(EntityTypeBuilder<Wholesaler> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).HasMaxLength(50).IsRequired();

            builder.HasMany(b => b.WholesalerStocks)
                .WithOne()
                .HasForeignKey(b => b.WholesalerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
