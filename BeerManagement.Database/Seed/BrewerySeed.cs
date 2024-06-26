using BeerManagement.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerManagement.Database.Seed
{
    public static class BrewerySeed
    {
        public static void Seed(this EntityTypeBuilder<Brewery> builder)
        {
            builder.HasData(
                new Brewery()
                {
                    Id = Guid.Parse("49949cfb-6027-499a-9208-ec6b8ceb0ba6"),
                    Name = "Leffe"
                }
            );
        }
    }
}
