using BeerManagement.Domain;

namespace BeerManagement.IDatabase
{
    public interface IBreweryDL
    {
        Task<List<Brewery>> GetAllAsync();
        Task<Brewery?> GetByIdAsync(Guid id);
        Task<Brewery> InsertAsync(Brewery brewery);
        Task<Brewery?> UpdateAsync(Brewery brewery);
        Task DeleteAsync(Guid id);
    }
}
