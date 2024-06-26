namespace BeerManagement.Domain
{
    public class OfferSummary
    {
        public Wholesaler? Wholesaler { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OfferBeerSummary>? OfferBeerSummary { get; set; }
    }
}
