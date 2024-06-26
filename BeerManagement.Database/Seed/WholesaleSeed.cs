using BeerManagement.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerManagement.Database.Seed
{
    public static class WholesaleSeed
    {
        public static void Seed(this EntityTypeBuilder<Wholesaler> builder)
        {
            builder.HasData(
                new Wholesaler()
                {
                    Id = Guid.Parse("adfb1b02-b2b8-45e1-bcf1-b29eada93092"),
                    Name = "GeneDrinks"
                }
            );
        }
    }
}
