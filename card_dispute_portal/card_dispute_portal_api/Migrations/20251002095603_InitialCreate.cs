using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace card_dispute_portal.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Merchant = table.Column<string>(type: "TEXT", nullable: false),
                    CardLast4 = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    DisputeReason = table.Column<string>(type: "TEXT", nullable: true),
                    DisputeStatus = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardTransactions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CardTransactions",
                columns: new[] { "Id", "Amount", "CardLast4", "CreatedDate", "Date", "Description", "DisputeReason", "DisputeStatus", "Merchant", "ModifiedDate" },
                values: new object[,]
                {
                    { 1, 120.50m, "1234", new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2025, 10, 2), "Groceries", null, 0, "Store A", null },
                    { 2, 45.00m, "5678", new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2025, 10, 2), "Fuel", null, 0, "Store B", null },
                    { 3, 75.25m, "9876", new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateOnly(2025, 10, 2), "Electronics", null, 0, "Store C", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardTransactions");
        }
    }
}
