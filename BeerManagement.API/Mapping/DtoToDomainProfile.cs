using AutoMapper;
using BeerManagement.API.Dto;
using BeerManagement.Domain;

namespace BeerManagement.API.Mapping
{
    public class DtoToDomainProfile : Profile
    {
        public DtoToDomainProfile() : base(nameof(DomainToDtoProfile))
        {
            CreateMap<BeerDto, Beer>();
            CreateMap<BreweryDto, Brewery>();
            CreateMap<WholesalerDto, Wholesaler>();
            CreateMap<WholesalerStockDto, WholesalerStock>();
            CreateMap<RequestOrderedBeerDto, RequestOrderBeer>();
        }
    }
}
