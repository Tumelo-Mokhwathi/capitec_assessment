namespace small_business_invoice_tracker.Models
{
    public class BaseEntity<TKey>
    {
        public TKey? Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedDate { get; set; }
    }
}
