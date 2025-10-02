using System.Net;

namespace small_business_invoice_tracker.Response
{
    public record ErrorResponse(HttpStatusCode Code, string Message, string Source);
}
