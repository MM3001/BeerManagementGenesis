using BeerManagement.Domain;

namespace BeerManagement.IBusiness
{
    public interface IWholesalerStockBL
    {
        Task<List<WholesalerStock>> GetAllAsync();
        Task<WholesalerStock?> GetByIdAsync(Guid id);
        Task<WholesalerStock> InsertAsync(WholesalerStock wholesalerStock);
        Task<WholesalerStock?> UpdateAsync(WholesalerStock wholesalerStock);
        Task DeleteAsync(Guid id);
    }
}
