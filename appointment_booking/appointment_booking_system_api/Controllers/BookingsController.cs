using appointment_booking_system.Models;
using appointment_booking_system.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace appointment_booking_system.Controllers
{
    [Route("api/[controller]")]
    public class BookingsController : GenericController<Booking, int>
    {
        private readonly IBookingService _service;

        public BookingsController(IBookingService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var result = await _service.GetAllAsync();

            return Ok(result, "Get");
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBooking([FromBody] Booking booking)
        {
            var result = await _service.CreateBookingAsync(booking);

            return result.Success && result.Booking != null
                ? Ok(result.Booking, "Booking Created")
                : Error(result.Error ?? "Unknown error", "Booking Created");
        }
    }
}
