using AutoMapper;
using BeerManagement.API.Dto;
using BeerManagement.Database.Logic;
using BeerManagement.Domain;
using BeerManagement.IBusiness;
using Microsoft.AspNetCore.Mvc;

namespace BeerManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BreweryController : ControllerBase
    {
        private readonly IBreweryBL _breweryBL;
        private readonly IMapper _mapper;

        public BreweryController(IBreweryBL beerBL, IMapper mapper)
        {
            _breweryBL = beerBL;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _breweryBL.GetAllAsync();

            var dto = _mapper.Map<List<BreweryDto>>(result);

            return Ok(dto);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _breweryBL.GetByIdAsync(id);

            var dto = _mapper.Map<BreweryDto>(result);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(BreweryDto breweryDto)
        {
            var brewery = _mapper.Map<Brewery>(breweryDto);

            var result = await _breweryBL.InsertAsync(brewery);

            return Ok(_mapper.Map<BreweryDto>(result));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(BreweryDto breweryDto)
        {
            var brewery = _mapper.Map<Brewery>(breweryDto);

            var result = await _breweryBL.UpdateAsync(brewery);

            return Ok(_mapper.Map<BreweryDto>(result));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _breweryBL.DeleteAsync(id);

            return Ok();
        }
    }
}
