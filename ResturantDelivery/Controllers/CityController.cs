using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResturantDelivery.Services;

namespace ResturantDelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly cityService _cityService;

        public CityController(cityService cityService)
        {
            _cityService = cityService;

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _cityService.GetAllCitiesAsync();
            return Ok(cities);
        }
    }
}
