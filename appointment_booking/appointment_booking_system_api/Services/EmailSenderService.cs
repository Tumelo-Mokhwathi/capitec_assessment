using appointment_booking_system.Configurations;
using appointment_booking_system.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace appointment_booking_system.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly string _smtpHost;
        private readonly int _smtpPort;
        private readonly string _fromEmail;
        private readonly string _appPassword;
        public EmailSenderService(IOptions<EmailSettings> options)
        {
            _fromEmail = options.Value.FromEmail;
            _appPassword = options.Value.AppPassword;
            _smtpPort = options.Value.SmtpPort;
            _smtpHost = options.Value.SmtpHost;
        }

        public async Task SendBookingConfirmationAsync(string toEmail, string subject, string body)
        {
            using var message = new MailMessage();
            message.From = new MailAddress(_fromEmail);
            message.To.Add(new MailAddress(toEmail));
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;
            message.Priority = MailPriority.Normal;

            using var client = new SmtpClient(_smtpHost, _smtpPort);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(_fromEmail, _appPassword);

            await client.SendMailAsync(message);
        }
    }
}
