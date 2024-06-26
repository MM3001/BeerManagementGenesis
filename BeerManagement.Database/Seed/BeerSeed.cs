using BeerManagement.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerManagement.Database.Seed
{
    public static class BeerSeed
    {
        public static void Seed(this EntityTypeBuilder<Beer> builder)
        {
            builder.HasData(
                new Beer()
                {
                    Id = Guid.Parse("ccb534da-6a31-44f3-9995-faa0301a8f31"),
                    Name = "Leffe Blonde",
                    Price = 2.2m,
                    AlcoholLevel = 6.6m,
                    BreweryId = Guid.Parse("49949cfb-6027-499a-9208-ec6b8ceb0ba6")
                },
                new Beer()
                {
                    Id = Guid.Parse("4341fe34-68b6-49f1-aed1-d3ff0dd1a830"),
                    Name = "Leffe Blonde 0.0",
                    Price = 2.1m,
                    AlcoholLevel = 0,
                    BreweryId = Guid.Parse("49949cfb-6027-499a-9208-ec6b8ceb0ba6")
                },
                new Beer()
                {
                    Id = Guid.Parse("e762513e-eb38-4e16-a0e3-e0fb0203d89c"),
                    Name = "Leffe Prestige",
                    Price = 2.2m,
                    AlcoholLevel = 8.5m,
                    BreweryId = Guid.Parse("49949cfb-6027-499a-9208-ec6b8ceb0ba6")
                },
                new Beer()
                {
                    Id = Guid.Parse("be795fdb-dfd8-4b81-b85f-fa372599ad3b"),
                    Name = "Leffe Ruby",
                    Price = 2.5m,
                    AlcoholLevel = 5,
                    BreweryId = Guid.Parse("49949cfb-6027-499a-9208-ec6b8ceb0ba6")
                },
                new Beer()
                {
                    Id = Guid.Parse("38f9d512-b892-4149-a28b-0fddef0e75f1"),
                    Name = "Leffe Ruby 0.0",
                    Price = 2.4m,
                    AlcoholLevel = 0,
                    BreweryId = Guid.Parse("49949cfb-6027-499a-9208-ec6b8ceb0ba6")
                },
                new Beer()
                {
                    Id = Guid.Parse("4814c82c-df0d-4794-8815-a15acf72f79a"),
                    Name = "Leffe rituel",
                    Price = 3m,
                    AlcoholLevel = 9,
                    BreweryId = Guid.Parse("49949cfb-6027-499a-9208-ec6b8ceb0ba6")
                },
                new Beer()
                {
                    Id = Guid.Parse("f387ad39-e17a-4bc6-bab0-a12236451943"),
                    Name = "Leffe tripple",
                    Price = 3m,
                    AlcoholLevel = 8.5m,
                    BreweryId = Guid.Parse("49949cfb-6027-499a-9208-ec6b8ceb0ba6")
                },
                new Beer()
                {
                    Id = Guid.Parse("ec8405d7-c55c-41cb-9bfd-7a28696c36d5"),
                    Name = "Leffe ambrée",
                    Price = 2.8m,
                    AlcoholLevel = 6.6m,
                    BreweryId = Guid.Parse("49949cfb-6027-499a-9208-ec6b8ceb0ba6")
                }
            );
        }
    }
}
