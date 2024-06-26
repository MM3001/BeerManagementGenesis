using BeerManagement.Domain;

namespace BeerManagement.IDatabase
{
    public interface IBeerDL
    {
        Task<List<Beer>> GetAllAsync();
        Task<Beer?> GetByIdAsync(Guid id);
        Task<Beer> InsertAsync(Beer beer);
        Task<Beer?> UpdateAsync(Beer beer);
        Task DeleteAsync(Guid id);
    }
}
