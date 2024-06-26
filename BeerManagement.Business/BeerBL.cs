using BeerManagement.Domain;
using BeerManagement.IBusiness;
using BeerManagement.IDatabase;

namespace BeerManagement.Business
{
    public class BeerBL : IBeerBL
    {
        private readonly IBeerDL _beerDL;

        public BeerBL(IBeerDL beerDL)
        {
            _beerDL = beerDL;
        }

        public async Task<List<Beer>> GetAllAsync()
        {
            return await _beerDL.GetAllAsync();
        }

        public async Task<Beer?> GetByIdAsync(Guid id)
        {
            return await _beerDL.GetByIdAsync(id);
        }

        public async Task<Beer> InsertAsync(Beer beer)
        {
            return await _beerDL.InsertAsync(beer);
        }

        public async Task<Beer?> UpdateAsync(Beer beer)
        {
            return await _beerDL.UpdateAsync(beer);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _beerDL.DeleteAsync(id);
        }
    }
}
