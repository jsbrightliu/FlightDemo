using AutoMapper;
using Flight.IServices;
using Flight.Models.Entities;
using Flight.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Flight.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private readonly IAirportService _airPortService;
        private readonly IMapper _mapper;

        public AirportController(IAirportService airPortService, IMapper mapper)
        {
            _airPortService = airPortService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<PagedResult<AirportDto>> GetPagedList([FromQuery]int page, [FromQuery]int rows)
        {
            var airports = await _airPortService.GetPagedListAsync(page, rows);
            var count = await _airPortService.CountAsync();

            var dtos = _mapper.Map<IList<AirportDto>>(airports);

            return new PagedResult<AirportDto>(count, dtos);
        }

        [HttpGet("{id:int}")]
        public async Task<AirportDto> Get([FromRoute] int id)
        {
            var airport = await _airPortService.GetAsync(id);

            var dto = _mapper.Map<AirportDto>(airport);

            return dto;
        }

        [HttpPost("{id:int}")]
        public async Task<CommonResult> CreateOrUpdate([FromRoute] int id, [FromForm] AirportInput input)
        {
            var airport = await _airPortService.GetAsync(id) ?? new Airport();

            airport.Name = input.Name;
            airport.Code = input.Code;

            if (airport.Id > 0)
                await _airPortService.UpdateAsync(airport);
            else
                await _airPortService.AddAsync(airport);

            return CommonResult.Succeed();
        }

        [HttpDelete("{id:int}")]
        public async Task<CommonResult> Delete([FromRoute] int id)
        {
            await _airPortService.DeleteAsync(id);

            return CommonResult.Succeed();
        }
    }
}
