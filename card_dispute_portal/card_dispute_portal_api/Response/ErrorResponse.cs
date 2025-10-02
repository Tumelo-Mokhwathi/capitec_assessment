using System.Net;

namespace card_dispute_portal.Response
{
    public record ErrorResponse(HttpStatusCode Code, string Message, string Source);
}
