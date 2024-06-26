using BeerManagement.Domain;
using BeerManagement.IDatabase;
using Microsoft.EntityFrameworkCore;

namespace BeerManagement.Database.Logic
{
    public class WholesalerStockDL : IWholesalerStockDL
    {
        private readonly BeerContext _beerContext;

        public WholesalerStockDL(BeerContext beerContext)
        {
            _beerContext = beerContext;
        }

        public async Task<List<WholesalerStock>> GetAllAsync()
        {
            return await _beerContext.WholesalerStocks.ToListAsync();
        }

        public async Task<WholesalerStock?> GetByIdAsync(Guid id)
        {
            return await _beerContext.WholesalerStocks.Where(b => b.Id == id).FirstOrDefaultAsync();
        }

        public async Task<WholesalerStock> InsertAsync(WholesalerStock wholesalerStock)
        {
            _beerContext.Add(wholesalerStock);
            await _beerContext.SaveChangesAsync();

            return wholesalerStock;
        }

        public async Task<WholesalerStock?> UpdateAsync(WholesalerStock wholesalerStock)
        {
            var dbWholesalerStock = await GetByIdAsync(wholesalerStock.Id);

            if (dbWholesalerStock != null)
            {
                dbWholesalerStock.WholesalerId = wholesalerStock.WholesalerId;
                dbWholesalerStock.BeerId = wholesalerStock.BeerId;
                dbWholesalerStock.Quantity = wholesalerStock.Quantity;

                await _beerContext.SaveChangesAsync();

                return dbWholesalerStock;
            }

            return null;
        }

        public async Task DeleteAsync(Guid id)
        {
            var dbWholesalerStock = await GetByIdAsync(id);

            if (dbWholesalerStock != null)
            {
                _beerContext.Remove(dbWholesalerStock);
                await _beerContext.SaveChangesAsync();
            }
        }
    }
}
