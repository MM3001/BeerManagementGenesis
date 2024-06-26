namespace BeerManagement.API.Dto
{
    public class WholesalerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<WholesalerStockDto>? WholesalerStocks { get; set; }
    }
}
