using BeerManagement.Domain;

namespace BeerManagement.IBusiness
{
    public interface IWholesalerBL
    {
        Task<List<Wholesaler>> GetAllAsync();
        Task<Wholesaler?> GetByIdAsync(Guid id);
        Task<Wholesaler> InsertAsync(Wholesaler beer);
        Task<Wholesaler?> UpdateAsync(Wholesaler beer);
        Task DeleteAsync(Guid id);
        Task<OfferSummary> GetOfferAsync(Guid wholeSelerId, List<RequestOrderBeer>? orderedBeers);
    }
}
