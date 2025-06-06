﻿using System.Net.Mail;
using System.Net;

namespace ResturantDelivery.Services
{
    public class EmailService :IEmailService

    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
         
            public async Task SendOrderConfirmEmailAsync(string toEmail, string subject, string body)
            {
                using var smtpClient = new SmtpClient(_configuration["Smtp:Host"], int.Parse(_configuration["Smtp:Port"]))
                {
                    Credentials = new NetworkCredential(_configuration["Smtp:Username"], _configuration["Smtp:Password"]),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_configuration["Smtp:Username"]),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(toEmail);

                await smtpClient.SendMailAsync(mailMessage);

            }
}
}

