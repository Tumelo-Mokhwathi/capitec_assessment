using appointment_booking_system.DataAccess;
using appointment_booking_system.Models;
using appointment_booking_system.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace appointment_booking_system.Services
{
    public class BookingService : IBookingService
    {
        private readonly IEmailSenderService _email;

        private readonly ApplicationDbContext _context;

        public BookingService(ApplicationDbContext context, IEmailSenderService email)
        {
            _context = context;
            _email = email;
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task<(bool Success, string? Error, Booking? Booking)> CreateBookingAsync(Booking booking)
        {
            booking.CreatedDate = booking.CreatedDate.Date;

            await using var tx = await _context.Database.BeginTransactionAsync();
            
            try
            {
                if (await _context.Bookings.AnyAsync(b =>
                    b.Branch == booking.Branch &&
                    b.Date == booking.Date &&
                    b.TimeSlot == booking.TimeSlot))
                    return (false, "Selected slot already booked.", null);

                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();
                await tx.CommitAsync();

                var subject = "Booking Confirmation";
                var body = $@"
                    <h3>Booking Confirmed!</h3>
                    <p>Branch: {booking.Branch}</p>
                    <p>Date: {booking.Date:yyyy-MM-dd}</p>
                    <p>Time Slot: {booking.TimeSlot}</p>
                    <p>Name: {booking.Name}</p>
                    <p>Email: {booking.Email}</p>
                ";

                await _email.SendBookingConfirmationAsync(booking.Email, subject, body);

                return (true, null, booking);
            }
            catch (DbUpdateException dbEx)
            {
                return (false, dbEx.Message, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }
    }
}
