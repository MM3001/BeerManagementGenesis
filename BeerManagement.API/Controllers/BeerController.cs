using AutoMapper;
using BeerManagement.API.Dto;
using BeerManagement.Domain;
using BeerManagement.IBusiness;
using Microsoft.AspNetCore.Mvc;

namespace BeerManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BeerController : ControllerBase
    {
        private readonly IBeerBL _beerBL;
        private readonly IMapper _mapper;

        public BeerController(IBeerBL beerBL, IMapper mapper)
        {
            _beerBL = beerBL;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _beerBL.GetAllAsync();

            var dto = _mapper.Map<List<BeerDto>>(result);

            return Ok(dto);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _beerBL.GetByIdAsync(id);

            var dto = _mapper.Map<BeerDto>(result);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(BeerDto beerDto)
        {
            var beer = _mapper.Map<Beer>(beerDto);

            var result = await _beerBL.InsertAsync(beer);

            return Ok(_mapper.Map<BeerDto>(result));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(BeerDto beerDto)
        {
            var beer = _mapper.Map<Beer>(beerDto);

            var result = await _beerBL.UpdateAsync(beer);

            return Ok(_mapper.Map<BeerDto>(result));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _beerBL.DeleteAsync(id);

            return Ok();
        }
    }
}
