using BeerManagement.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerManagement.Database.Seed
{
    public static class WholesaleStockSeed
    {
        public static void Seed(this EntityTypeBuilder<WholesalerStock> builder)
        {

            builder.HasData(
                new WholesalerStock()
                {
                    Id = Guid.NewGuid(),
                    WholesalerId = Guid.Parse("adfb1b02-b2b8-45e1-bcf1-b29eada93092"),
                    BeerId = Guid.Parse("ccb534da-6a31-44f3-9995-faa0301a8f31"),
                    Quantity = 20
                },
                new WholesalerStock()
                {
                    Id = Guid.NewGuid(),
                    WholesalerId = Guid.Parse("adfb1b02-b2b8-45e1-bcf1-b29eada93092"),
                    BeerId = Guid.Parse("4341fe34-68b6-49f1-aed1-d3ff0dd1a830"),
                    Quantity = 20
                },
                new WholesalerStock()
                {
                    Id = Guid.NewGuid(),
                    WholesalerId = Guid.Parse("adfb1b02-b2b8-45e1-bcf1-b29eada93092"),
                    BeerId = Guid.Parse("e762513e-eb38-4e16-a0e3-e0fb0203d89c"),
                    Quantity = 20
                },
                new WholesalerStock()
                {
                    Id = Guid.NewGuid(),
                    WholesalerId = Guid.Parse("adfb1b02-b2b8-45e1-bcf1-b29eada93092"),
                    BeerId = Guid.Parse("be795fdb-dfd8-4b81-b85f-fa372599ad3b"),
                    Quantity = 20
                },
                new WholesalerStock()
                {
                    Id = Guid.NewGuid(),
                    WholesalerId = Guid.Parse("adfb1b02-b2b8-45e1-bcf1-b29eada93092"),
                    BeerId = Guid.Parse("38f9d512-b892-4149-a28b-0fddef0e75f1"),
                    Quantity = 20
                }
            );
        }
    }
}
