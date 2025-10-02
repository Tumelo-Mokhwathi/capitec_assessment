using appointment_booking_system.Models;

namespace appointment_booking_system.Services.Interfaces
{
    public interface IBookingService : IGenericService<Booking, int>
    {
        Task<(bool Success, string? Error, Booking? Booking)> CreateBookingAsync(Booking booking);
    }
}
