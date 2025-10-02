namespace appointment_booking_system.Services.Interfaces
{
    public interface IEmailSenderService
    {
        Task SendBookingConfirmationAsync(string toEmail, string subject, string body);
    }
}
