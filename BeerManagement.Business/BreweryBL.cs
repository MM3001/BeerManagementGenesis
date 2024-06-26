using BeerManagement.Domain;
using BeerManagement.IBusiness;
using BeerManagement.IDatabase;

namespace BeerManagement.Business
{
    public class BreweryBL : IBreweryBL
    {
        private readonly IBreweryDL _breweryDL;

        public BreweryBL(IBreweryDL breweryDL)
        {
            _breweryDL = breweryDL;
        }

        public async Task<List<Brewery>> GetAllAsync()
        {
            return await _breweryDL.GetAllAsync();
        }
        public async Task<Brewery?> GetByIdAsync(Guid id)
        {
            return await _breweryDL.GetByIdAsync(id);
        }

        public async Task<Brewery> InsertAsync(Brewery brewery)
        {
            return await _breweryDL.InsertAsync(brewery);
        }

        public async Task<Brewery?> UpdateAsync(Brewery brewery)
        {
            return await _breweryDL.UpdateAsync(brewery);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _breweryDL.DeleteAsync(id);
        }
    }
}
