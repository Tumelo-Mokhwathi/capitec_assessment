using card_dispute_portal.Helpers;
using card_dispute_portal.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace card_dispute_portal.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<CardTransaction> CardTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CardTransaction>().HasData(
            new CardTransaction
            {
                Id = 1,
                Date = new DateOnly(2025, 10, 2),
                Amount = 120.50m,
                Merchant = "Store A",
                CardLast4 = "1234",
                Description = "Groceries",
                DisputeReason = null,
                DisputeStatus = DisputeStatus.NotSubmitted,
                CreatedDate = new DateTime(2025, 10, 2, 0, 0, 0, DateTimeKind.Utc),
            },
            new CardTransaction
            {
                Id = 2,
                Date = new DateOnly(2025, 10, 2),
                Amount = 45.00m,
                Merchant = "Store B",
                CardLast4 = "5678",
                Description = "Fuel",
                DisputeReason = null,
                DisputeStatus = DisputeStatus.NotSubmitted,
                CreatedDate = new DateTime(2025, 10, 2, 0, 0, 0, DateTimeKind.Utc),
            },
            new CardTransaction
            {
                Id = 3,
                Date = new DateOnly(2025, 10, 2),
                Amount = 75.25m,
                Merchant = "Store C",
                CardLast4 = "9876",
                Description = "Electronics",
                DisputeReason = null,
                DisputeStatus = DisputeStatus.NotSubmitted,
                CreatedDate = new DateTime(2025, 10, 2, 0, 0, 0, DateTimeKind.Utc),
            }
           );
        }
    }
}
