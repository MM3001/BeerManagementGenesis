namespace BeerManagement.API.Dto
{
    public class OfferSummaryDto
    {
        public WholesalerDto? Wholesaler { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OfferBeerSummaryDto>? OfferBeerSummary { get; set; }
    }
}
