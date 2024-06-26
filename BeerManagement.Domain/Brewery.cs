namespace BeerManagement.Domain
{
    public class Brewery
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<Beer>? Beers { get; set; }
    }
}
