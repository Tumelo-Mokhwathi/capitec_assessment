using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace card_dispute_portal.Response
{
    public static class ActionResponse
    {
        public static IActionResult Success(HttpStatusCode code, object result, string source)
        {
            _ = result ?? throw new ArgumentNullException(nameof(result));
            _ = source ?? throw new ArgumentNullException(nameof(source));

            return new ObjectResult(new { code, result, source });
        }

        public static IActionResult Error(HttpStatusCode code, string message, string source)
        {
            _ = message ?? throw new ArgumentNullException(nameof(message));
            _ = source ?? throw new ArgumentNullException(nameof(source));

            return new ObjectResult(new ErrorResponse(code, message, source))
            {
                StatusCode = (int)code
            };
        }
    }
}
