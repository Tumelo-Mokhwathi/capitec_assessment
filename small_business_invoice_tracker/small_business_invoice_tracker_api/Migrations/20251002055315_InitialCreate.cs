using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace small_business_invoice_tracker.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerName = table.Column<string>(type: "TEXT", nullable: false),
                    IssueDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    DueDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Total = table.Column<decimal>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "CustomerName", "Description", "DueDate", "IssueDate", "ModifiedDate", "Price", "Status", "Total" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Acme Corp", "Website Development", new DateOnly(2025, 10, 22), new DateOnly(2025, 9, 22), null, 500.00m, 0, 500.00m },
                    { 2, new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Beta Ltd", "Mobile App Design", new DateOnly(2025, 9, 27), new DateOnly(2025, 9, 2), null, 1200.00m, 0, 1200.00m },
                    { 3, new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Charlie Industries", "Consulting Services", new DateOnly(2025, 10, 17), new DateOnly(2025, 9, 17), null, 800.00m, 1, 800.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");
        }
    }
}
