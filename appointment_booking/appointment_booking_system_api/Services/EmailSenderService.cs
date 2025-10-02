using appointment_booking_system.Services.Interfaces;
using System.Net;
using System.Net.Mail;

namespace appointment_booking_system.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly string _smtpHost = "smtp.gmail.com";
        private readonly int _smtpPort = 587;
        private readonly string _fromEmail = "GMAIL_ACCOUNT TO SEND EMAIL FROM"; // Replace with your actual Gmail account
        private readonly string _appPassword = "APP_PASSWORD"; // Replace with your actual app password

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
