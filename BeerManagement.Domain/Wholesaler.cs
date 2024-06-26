namespace BeerManagement.Domain
{
    public class Wholesaler
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<WholesalerStock>? WholesalerStocks { get; set; }
    }
}
