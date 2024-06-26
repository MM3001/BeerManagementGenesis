using AutoMapper;
using BeerManagement.API.Dto;
using BeerManagement.Domain;
using BeerManagement.IBusiness;
using Microsoft.AspNetCore.Mvc;

namespace BeerManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WholesalerStockController : ControllerBase
    {
        private readonly IWholesalerStockBL _wholesalerStockBL;
        private readonly IMapper _mapper;

        public WholesalerStockController(IWholesalerStockBL wholesaleStockBL, IMapper mapper)
        {
            _wholesalerStockBL = wholesaleStockBL;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _wholesalerStockBL.GetAllAsync();

            var dto = _mapper.Map<List<WholesalerStockDto>>(result);

            return Ok(dto);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _wholesalerStockBL.GetByIdAsync(id);

            var dto = _mapper.Map<WholesalerStockDto>(result);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(WholesalerStockDto wholesalerStockDto)
        {
            var wholesalerStock = _mapper.Map<WholesalerStock>(wholesalerStockDto);

            var result = await _wholesalerStockBL.InsertAsync(wholesalerStock);

            return Ok(_mapper.Map<WholesalerStockDto>(result));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(WholesalerStockDto wholesalerStockDto)
        {
            var wholesalerStock = _mapper.Map<WholesalerStock>(wholesalerStockDto);

            var result = await _wholesalerStockBL.UpdateAsync(wholesalerStock);

            return Ok(_mapper.Map<WholesalerStockDto>(result));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _wholesalerStockBL.DeleteAsync(id);

            return Ok();
        }
    }
}
