using BeerManagement.Domain;
using BeerManagement.IBusiness;
using BeerManagement.IDatabase;

namespace BeerManagement.Business
{
    public class WholesalerBL : IWholesalerBL
    {
        private readonly IWholesalerDL _wholeSalerDL;

        public WholesalerBL(IWholesalerDL wholeSaleDL)
        {
            _wholeSalerDL = wholeSaleDL;
        }

        public async Task<List<Wholesaler>> GetAllAsync()
        {
            return await _wholeSalerDL.GetAllAsync();
        }

        public async Task<Wholesaler?> GetByIdAsync(Guid id)
        {
            return await _wholeSalerDL.GetByIdAsync(id);
        }

        public async Task<Wholesaler> InsertAsync(Wholesaler wholesaler)
        {
            return await _wholeSalerDL.InsertAsync(wholesaler);
        }

        public async Task<Wholesaler?> UpdateAsync(Wholesaler wholesaler)
        {
            return await _wholeSalerDL.UpdateAsync(wholesaler);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _wholeSalerDL.DeleteAsync(id);
        }

        public async Task<OfferSummary> GetOfferAsync(Guid wholeSelerId, List<RequestOrderBeer>? orderedBeers)
        {
            Wholesaler wholeseller = await ValidateOffer(wholeSelerId, orderedBeers);

            var offerBeersSummary = new List<OfferBeerSummary>();

            foreach (var beer in orderedBeers)
            {
                var dbBeer = wholeseller.WholesalerStocks.First(x => x.BeerId == beer.BeerId).Beer;
                OfferBeerSummary offerBeerSummary = new OfferBeerSummary()
                {
                    Beer = dbBeer,
                };

                ComputeSubTotalPerBeer(beer, dbBeer, offerBeerSummary);

                offerBeersSummary.Add(offerBeerSummary);
            }

            OfferSummary offerSummary = new OfferSummary()
            {
                OfferBeerSummary = offerBeersSummary,
                Wholesaler = wholeseller,
                TotalAmount = offerBeersSummary.Sum(x => x.SubTotal)
            };

            return offerSummary;
        }

        private static void ComputeSubTotalPerBeer(RequestOrderBeer beer, Beer? retrievedBeer, OfferBeerSummary offerBeerSummary)
        {
            if (beer.Quantity >= 20) offerBeerSummary.SubTotal = retrievedBeer!.Price * beer.Quantity * 0.8m;
            else if (beer.Quantity >= 10) offerBeerSummary.SubTotal = retrievedBeer!.Price * beer.Quantity * 0.9m;
            else offerBeerSummary.SubTotal = retrievedBeer!.Price * beer.Quantity;
        }

        private async Task<Wholesaler> ValidateOffer(Guid wholeSelerId, List<RequestOrderBeer>? orderedBeers)
        {
            var wholeseller = await GetByIdAsync(wholeSelerId) ?? throw new Exception("Wholeseller Doesn't exist !");

            if (orderedBeers == null || orderedBeers.Count == 0) throw new Exception("At least one beer should be ordered !");

            if (orderedBeers.Select(x => x.BeerId).Distinct().Count() != orderedBeers.Count()) throw new Exception("Beer found multiple times !");

            if (orderedBeers.Select(x => x.BeerId).Except(wholeseller.WholesalerStocks.Select(y => y.BeerId).ToList()).Any()) throw new Exception("Some beer not sold by wholeseller !");

            foreach (var orderedBeer in orderedBeers)
                if (orderedBeer.Quantity > wholeseller.WholesalerStocks.First(x => x.BeerId == orderedBeer.BeerId).Quantity) throw new Exception("Not enough beer availeble for this wholesaler !");
            return wholeseller;
        }
    }
}
