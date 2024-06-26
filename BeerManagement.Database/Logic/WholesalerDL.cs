using BeerManagement.Domain;
using BeerManagement.IDatabase;
using Microsoft.EntityFrameworkCore;

namespace BeerManagement.Database.Logic
{
    public class WholesalerDL : IWholesalerDL
    {
        private readonly BeerContext _beerContext;

        public WholesalerDL(BeerContext beerContext)
        {
            _beerContext = beerContext;
        }

        public async Task<List<Wholesaler>> GetAllAsync()
        {
            return await _beerContext.Wholesalers.ToListAsync();
        }

        public async Task<Wholesaler?> GetByIdAsync(Guid id)
        {
            return await _beerContext.Wholesalers.Include(x => x.WholesalerStocks).ThenInclude(y => y.Beer).Where(b => b.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Wholesaler> InsertAsync(Wholesaler wholesaler)
        {
            _beerContext.Add(wholesaler);
            await _beerContext.SaveChangesAsync();

            return wholesaler;
        }

        public async Task<Wholesaler?> UpdateAsync(Wholesaler wholesaler)
        {
            var dbWholesaler = await GetByIdAsync(wholesaler.Id);

            if (dbWholesaler != null)
            {
                dbWholesaler.Name = wholesaler.Name;

                await _beerContext.SaveChangesAsync();

                return dbWholesaler;
            }

            return null;
        }

        public async Task DeleteAsync(Guid id)
        {
            var dbWholesaler = await GetByIdAsync(id);

            if (dbWholesaler != null)
            {
                _beerContext.Remove(dbWholesaler);
                await _beerContext.SaveChangesAsync();
            }
        }
    }
}
