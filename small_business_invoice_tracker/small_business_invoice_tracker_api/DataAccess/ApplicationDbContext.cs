using Microsoft.EntityFrameworkCore;
using small_business_invoice_tracker.Helpers;
using small_business_invoice_tracker.Models;

namespace small_business_invoice_tracker.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Invoice>().HasData(
                new Invoice
                {
                    Id = 1,
                    CustomerName = "Acme Corp",
                    IssueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-10)),
                    DueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(20)),
                    Total = 500.00m,
                    Description = "Website Development",
                    Price = 500.00m,
                    Status = InvoiceStatus.Pending,
                    CreatedDate = new DateTime(2025, 10, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Invoice
                {
                    Id = 2,
                    CustomerName = "Beta Ltd",
                    IssueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-30)),
                    DueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-5)),
                    Total = 1200.00m,
                    Description = "Mobile App Design",
                    Price = 1200.00m,
                    CreatedDate = new DateTime(2025, 10, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Invoice
                {
                    Id = 3,
                    CustomerName = "Charlie Industries",
                    IssueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-15)),
                    DueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(15)),
                    Total = 800.00m,
                    Description = "Consulting Services",
                    Price = 800.00m,
                    Status = InvoiceStatus.Paid,
                    CreatedDate = new DateTime(2025, 10, 1, 0, 0, 0, DateTimeKind.Utc)
                }
            );
        }
    }
}
