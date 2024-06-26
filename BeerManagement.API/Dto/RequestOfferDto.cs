namespace BeerManagement.API.Dto
{
    public class RequestOfferDto
    {
        public Guid WholesellerId { get; set; }
        public List<RequestOrderedBeerDto>? OrderedBeers { get; set; }
    }
}
