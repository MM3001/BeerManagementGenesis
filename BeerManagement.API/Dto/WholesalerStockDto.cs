namespace BeerManagement.API.Dto
{
    public class WholesalerStockDto
    {
        public Guid Id { get; set; }
        public Guid BeerId { get; set; }
        public Guid WholesalerId { get; set; }
        public int Quantity { get; set; }

        public BeerDto? Beer { get; set; }
    }
}
