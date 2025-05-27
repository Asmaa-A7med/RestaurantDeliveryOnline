using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResturantDelivery.Dtos;
using ResturantDelivery.Services;

namespace ResturantDelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAuthController : ControllerBase
    {
        private readonly CustomerService _customerService;
        public CustomerAuthController(CustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CustomerRegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var token = await _customerService.RegisterAsync(dto);

            if (token == null)
                return BadRequest("Email already exists");

            return Ok(new { token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] CustomerLoginDto dto)
        {
            var result = await _customerService.LoginAsync(dto);

            if (result == null)
                return Unauthorized("Invalid email or password");

            return Ok(result);
        }
    }
}

