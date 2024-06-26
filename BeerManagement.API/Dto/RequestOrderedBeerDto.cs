namespace BeerManagement.API.Dto
{
    public class RequestOrderedBeerDto
    {
        public Guid BeerId { get; set; }
        public int Quantity { get; set; }
    }
}
