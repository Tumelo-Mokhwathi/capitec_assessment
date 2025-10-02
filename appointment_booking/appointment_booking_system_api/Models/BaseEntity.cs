namespace appointment_booking_system.Models
{
    public class BaseEntity<TKey>
    {
        public TKey? Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedDate { get; set; }
    }
}
