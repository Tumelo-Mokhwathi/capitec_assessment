namespace appointment_booking_system.Configurations
{
    public class EmailSettings
    {
        public string FromEmail { get; set; } = string.Empty;
        public string AppPassword { get; set; } = string.Empty;
        public string SmtpHost { get; set; } = string.Empty;
        public int  SmtpPort { get; set; }
    }
}
