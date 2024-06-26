using AutoMapper;
using BeerManagement.API.Dto;
using BeerManagement.Domain;
using BeerManagement.IBusiness;
using Microsoft.AspNetCore.Mvc;

namespace BeerManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WholesalerController : ControllerBase
    {
        private readonly IWholesalerBL _wholesalerBL;
        private readonly IMapper _mapper;

        public WholesalerController(IWholesalerBL wholesaleBL, IMapper mapper)
        {
            _wholesalerBL = wholesaleBL;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _wholesalerBL.GetAllAsync();

            var dto = _mapper.Map<List<WholesalerDto>>(result);

            return Ok(dto);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _wholesalerBL.GetByIdAsync(id);

            var dto = _mapper.Map<WholesalerDto>(result);

            return Ok(dto);
        }

        [HttpPost("offer")]
        public async Task<IActionResult> GetOfferAsync([FromBody] RequestOfferDto requestOfferDto)
        {
            try
            {
                var result = await _wholesalerBL.GetOfferAsync(requestOfferDto.WholesellerId, _mapper.Map<List<RequestOrderBeer>>(requestOfferDto.OrderedBeers));
                return Ok(_mapper.Map<OfferSummaryDto>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(WholesalerDto wholesalerDto)
        {
            var wholesaler = _mapper.Map<Wholesaler>(wholesalerDto);

            var result = await _wholesalerBL.InsertAsync(wholesaler);

            return Ok(_mapper.Map<WholesalerDto>(result));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(WholesalerDto wholesalerDto)
        {
            var wholesaler = _mapper.Map<Wholesaler>(wholesalerDto);

            var result = await _wholesalerBL.UpdateAsync(wholesaler);

            return Ok(_mapper.Map<WholesalerDto>(result));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _wholesalerBL.DeleteAsync(id);

            return Ok();
        }
    }
}
