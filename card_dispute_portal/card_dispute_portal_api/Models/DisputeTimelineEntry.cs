namespace card_dispute_portal.Models
{
    public class DisputeTimelineEntry : BaseEntity<int>
    {
        public int DisputeId { get; set; }
        public DateTime At { get; set; } = DateTime.UtcNow;
        public string Note { get; set; } = string.Empty;
    }
}
