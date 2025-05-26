using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResturantDelivery.Dtos;
using ResturantDelivery.Services;

namespace ResturantDelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfirmationController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IConfiguration _config;
        public ConfirmationController(IEmailService emailService, IConfiguration config)
        {
            _emailService = emailService;
            _config = config;
        }
        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout([FromBody] OrderDto order)
        {
            if (order == null || order.Customer == null)
                return BadRequest("Invalid order data");

            var toEmail = order.Customer.Email;
            var subject = "Restaurant Delivery - Your Order Has Been Received";

            var itemsList = string.Join("<br/>", order.Items.Select(item =>
                $"- {item.Name} × {item.Quantity} = {item.SubTotal} EGP"));

            var body = $@"
    <h2>Restaurant Delivery</h2>
    <h3>Your order has been received and is being processed.</h3>
    <hr/>
    <h3>Order Details:</h3>
    {itemsList}
    <br/><br/>
    <strong>Total Amount:</strong> {order.TotalAmount} EGP
    <br/><br/>
    <p>Thank you for choosing Restaurant Delivery. We hope you enjoy your meal!</p>
";

            await _emailService.SendOrderConfirmEmailAsync(toEmail, subject, body);

            return Ok(new { message = "Order placed and confirmation email sent." });
        }
    }
}
