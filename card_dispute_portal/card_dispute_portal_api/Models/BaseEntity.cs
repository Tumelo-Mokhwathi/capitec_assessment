namespace card_dispute_portal.Models
{
    public class BaseEntity<TKey>
    {
        public TKey? Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedDate { get; set; }
    }
}
