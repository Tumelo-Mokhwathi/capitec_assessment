namespace appointment_booking_system.Models
{
    public class Booking : BaseEntity<int>
    {
        public string Branch { get; set; } = string.Empty;
        public DateOnly Date { get; set; }
        public string TimeSlot { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

    }
}
