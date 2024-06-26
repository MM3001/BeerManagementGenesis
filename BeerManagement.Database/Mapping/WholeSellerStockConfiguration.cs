using BeerManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerManagement.Database.Mapping
{
    public class WholeSellerStockConfiguration : IEntityTypeConfiguration<WholesalerStock>
    {
        public void Configure(EntityTypeBuilder<WholesalerStock> builder)
        {
            builder.HasKey(b => b.Id);
            

            builder.HasOne(b => b.Beer)
                .WithMany()
                .HasForeignKey(b => b.BeerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
