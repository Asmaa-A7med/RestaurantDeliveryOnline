using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResturantDelivery.Services;

namespace ResturantDelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResturantController : ControllerBase
    {
        private readonly ResturantService _resturantService;

        public ResturantController(ResturantService resturantService)
        {
            _resturantService = resturantService;
            
        }

        // get all :
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = await _resturantService.GetAllRestaurantsAsync();
            return Ok(restaurants);
        }

        // search resturant :
        [HttpGet("SearchResturant")]
        public async Task<IActionResult> Search(string? name, string? cityName)
        {
            var results = await _resturantService.SearchRestaurantsAsync(name, cityName);
            return Ok(results);
        }
    }
}
