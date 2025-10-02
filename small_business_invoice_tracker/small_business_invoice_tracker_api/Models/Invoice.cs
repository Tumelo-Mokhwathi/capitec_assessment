using small_business_invoice_tracker.Helpers;

namespace small_business_invoice_tracker.Models
{
    public class Invoice : BaseEntity<int>
    {
        public string CustomerName { get; set; } = string.Empty;
        public DateOnly IssueDate { get; set; }
        public DateOnly DueDate { get; set; }
        public decimal Total { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public InvoiceStatus Status { get; set; }
    }
}
