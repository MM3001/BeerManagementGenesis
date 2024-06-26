﻿namespace BeerManagement.Domain
{
    public class Beer
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal AlcoholLevel { get; set; }
        public Guid BreweryId { get; set; }
    }
}