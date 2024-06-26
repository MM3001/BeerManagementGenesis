using AutoMapper;
using BeerManagement.API.Dto;
using BeerManagement.Domain;

namespace BeerManagement.API.Mapping
{
    public class DomainToDtoProfile : Profile
    {
        public DomainToDtoProfile() : base(nameof(DomainToDtoProfile))
        {
            CreateMap<Beer, BeerDto>();
            CreateMap<Brewery, BreweryDto>();
            CreateMap<Wholesaler, WholesalerDto>();
            CreateMap<WholesalerStock, WholesalerStockDto>();
            CreateMap<RequestOrderBeer, RequestOrderedBeerDto>();
            CreateMap<OfferSummary, OfferSummaryDto>().ForPath(x => x.Wholesaler.WholesalerStocks, opt => opt.Ignore());
            CreateMap<OfferBeerSummary, OfferBeerSummaryDto>();
        }
    }
}
