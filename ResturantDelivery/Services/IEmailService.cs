namespace ResturantDelivery.Services
{
    public interface IEmailService
    {
        Task SendOrderConfirmEmailAsync(string toEmail, string subject, string body);
    }
}
