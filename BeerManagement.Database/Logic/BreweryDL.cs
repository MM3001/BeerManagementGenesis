using BeerManagement.Domain;
using BeerManagement.IDatabase;
using Microsoft.EntityFrameworkCore;

namespace BeerManagement.Database.Logic
{
    public class BreweryDL : IBreweryDL
    {
        private readonly BeerContext _beerContext;

        public BreweryDL(BeerContext beerContext)
        {
            _beerContext = beerContext;
        }

        public async Task<List<Brewery>> GetAllAsync()
        {
            return await _beerContext.Breweries.Include(b => b.Beers).ToListAsync();
        }

        public async Task<Brewery?> GetByIdAsync(Guid id)
        {
            return await _beerContext.Breweries.Where(b => b.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Brewery> InsertAsync(Brewery brewery)
        {
            _beerContext.Add(brewery);
            await _beerContext.SaveChangesAsync();

            return brewery;
        }

        public async Task<Brewery?> UpdateAsync(Brewery brewery)
        {
            var dbBeer = await GetByIdAsync(brewery.Id);

            if (dbBeer != null)
            {
                dbBeer.Name = brewery.Name;

                await _beerContext.SaveChangesAsync();

                return dbBeer;
            }

            return null;
        }

        public async Task DeleteAsync(Guid id)
        {
            var dbBrewery = await GetByIdAsync(id);

            if (dbBrewery != null)
            {
                _beerContext.Remove(dbBrewery);
                await _beerContext.SaveChangesAsync();
            }
        }
    }
}
