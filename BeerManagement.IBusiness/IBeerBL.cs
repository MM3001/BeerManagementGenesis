using BeerManagement.Domain;

namespace BeerManagement.IBusiness
{
    public interface IBeerBL
    {
        Task<List<Beer>> GetAllAsync();
        Task<Beer?> GetByIdAsync(Guid id);
        Task<Beer> InsertAsync(Beer beer);
        Task<Beer?> UpdateAsync(Beer beer);
        Task DeleteAsync(Guid id);
    }
}
