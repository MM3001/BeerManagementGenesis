using BeerManagement.Database.Mapping;
using BeerManagement.Database.Seed;
using BeerManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace BeerManagement.Database
{
    public partial class BeerContext : DbContext
    {
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brewery> Breweries { get; set; }
        public DbSet<Wholesaler> Wholesalers { get; set; }
        public DbSet<WholesalerStock> WholesalerStocks  { get; set; }
        public string DbPath { get; }

        public BeerContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "beer.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("bm");

            modelBuilder.ApplyConfiguration(new BeerConfiguration());
            modelBuilder.ApplyConfiguration(new BreweryConfiguration());
            modelBuilder.ApplyConfiguration(new WholesaleConfiguration());

            modelBuilder.Entity<Beer>().Seed();
            modelBuilder.Entity<Brewery>().Seed();
            modelBuilder.Entity<Wholesaler>().Seed();
            modelBuilder.Entity<WholesalerStock>().Seed();
        }
    }
}
