using BeerManagement.Domain;

namespace BeerManagement.IDatabase
{
    public interface IWholesalerDL
    {
        Task<List<Wholesaler>> GetAllAsync();
        Task<Wholesaler?> GetByIdAsync(Guid id);
        Task<Wholesaler> InsertAsync(Wholesaler beer);
        Task<Wholesaler?> UpdateAsync(Wholesaler beer);
        Task DeleteAsync(Guid id);
    }
}
