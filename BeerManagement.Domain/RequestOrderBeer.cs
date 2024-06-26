namespace BeerManagement.Domain
{
    public class RequestOrderBeer
    {
        public Guid BeerId { get; set; }
        public int Quantity { get; set; }
    }
}
