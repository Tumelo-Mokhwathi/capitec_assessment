using System.Net;

namespace appointment_booking_system.Response
{
    public record ErrorResponse(HttpStatusCode Code, string Message, string Source);
}
