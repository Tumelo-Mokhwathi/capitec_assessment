using appointment_booking_system.Models;
using Microsoft.EntityFrameworkCore;

namespace appointment_booking_system.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<Booking> Bookings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    Id = 1,
                    Branch = "Cape Town Branch",
                    TimeSlot = "09:00 - 10:00",
                    Name = "Peter",
                    Email = "test@gmail.com",
                    Address = "123 Demo Street",
                    Date = new DateOnly(2025, 10, 1),
                    CreatedDate = new DateTime(2025, 10, 1, 0, 0, 0, DateTimeKind.Utc),
                }
            );
        }
    }
}
