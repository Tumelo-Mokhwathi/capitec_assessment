using card_dispute_portal.Helpers;

namespace card_dispute_portal.Models
{
    public class CardTransaction : BaseEntity<int>
    {
        // Transaction info
        public DateOnly Date { get; set; }
        public decimal Amount { get; set; }
        public string Merchant { get; set; } = string.Empty;
        public string? CardLast4 { get; set; }
        public string? Description { get; set; }

        // Optional dispute info
        public string? DisputeReason { get; set; }
        public DisputeStatus? DisputeStatus { get; set; }
    }
}
