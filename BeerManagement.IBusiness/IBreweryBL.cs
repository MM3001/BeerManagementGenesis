using BeerManagement.Domain;

namespace BeerManagement.IBusiness
{
    public interface IBreweryBL
    {
        Task<List<Brewery>> GetAllAsync();
        Task<Brewery?> GetByIdAsync(Guid id);
        Task<Brewery> InsertAsync(Brewery brewery);
        Task<Brewery?> UpdateAsync(Brewery brewery);
        Task DeleteAsync(Guid id);
    }
}
