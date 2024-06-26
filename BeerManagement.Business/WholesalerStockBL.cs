using BeerManagement.Domain;
using BeerManagement.IBusiness;
using BeerManagement.IDatabase;

namespace BeerManagement.Business
{
    public class WholesalerStockBL : IWholesalerStockBL
    {
        private readonly IWholesalerStockDL _WholesalerStockDL;

        public WholesalerStockBL(IWholesalerStockDL WholesalerStockDL)
        {
            _WholesalerStockDL = WholesalerStockDL;
        }

        public async Task<List<WholesalerStock>> GetAllAsync()
        {
            return await _WholesalerStockDL.GetAllAsync();
        }

        public async Task<WholesalerStock?> GetByIdAsync(Guid id)
        {
            return await _WholesalerStockDL.GetByIdAsync(id);
        }

        public async Task<WholesalerStock> InsertAsync(WholesalerStock wholesalerStock)
        {
            return await _WholesalerStockDL.InsertAsync(wholesalerStock);
        }

        public async Task<WholesalerStock?> UpdateAsync(WholesalerStock wholesalerStock)
        {
            return await _WholesalerStockDL.UpdateAsync(wholesalerStock);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _WholesalerStockDL.DeleteAsync(id);
        }
    }
}
