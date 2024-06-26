namespace BeerManagement.API.Dto
{
    public class BreweryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<BeerDto>? Beers { get; set; }
    }
}
