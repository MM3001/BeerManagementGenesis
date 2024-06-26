namespace BeerManagement.Domain
{
    public class WholesalerStock
    {
        public Guid Id { get; set; }
        public Guid BeerId { get; set; }
        public Guid WholesalerId { get; set; }
        public int Quantity { get; set; }

        public Beer? Beer { get; set; }
    }
}
