using AutoMapper;
using Flight.Services;
using Flight.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Flight.Controllers
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

        public async Task<AirportDto> Index([FromQuery] int id)
        {
            var airport = await _airPortService.GetAsync(id);

            var dto = _mapper.Map<AirportDto>(airport);

            return dto;
        }
    }
}
