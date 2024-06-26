using BeerManagement.Domain;
using BeerManagement.IDatabase;
using Microsoft.EntityFrameworkCore;

namespace BeerManagement.Database.Logic
{
    public class BeerDL : IBeerDL
    {
        private readonly BeerContext _beerContext;

        public BeerDL(BeerContext beerContext)
        {
            _beerContext = beerContext;
        }

        public async Task<List<Beer>> GetAllAsync()
        {
            return await _beerContext.Beers.ToListAsync();
        }

        public async Task<Beer?> GetByIdAsync(Guid id)
        {
            return await _beerContext.Beers.Where(b => b.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Beer> InsertAsync(Beer beer)
        {
            _beerContext.Add(beer);
            await _beerContext.SaveChangesAsync();

            return beer;
        }

        public async Task<Beer?> UpdateAsync(Beer beer)
        {
            var dbBeer = await GetByIdAsync(beer.Id);

            if (dbBeer != null)
            {
                dbBeer.Name = beer.Name;
                dbBeer.Price = beer.Price;
                dbBeer.AlcoholLevel = beer.AlcoholLevel;

                await _beerContext.SaveChangesAsync();

                return dbBeer;
            }

            return null;
        }

        public async Task DeleteAsync(Guid id)
        {
            var dbBeer = await GetByIdAsync(id);

            if (dbBeer != null)
            {
                _beerContext.Remove(dbBeer);
                await _beerContext.SaveChangesAsync();
            }
        }
    }
}
