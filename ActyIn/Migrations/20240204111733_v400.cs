using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ActyIn.Migrations
{
    /// <inheritdoc />
    public partial class v400 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ApplicationImages",
                columns: new[] { "SportId", "ContentType", "FileName", "SportName" },
                values: new object[,]
                {
                    { 1, "application/json", "hiking.jpg", "hiking" },
                    { 2, "application/json", "basketball.jpg", "basketball" },
                    { 3, "application/json", "chess.jpg", "chess" },
                    { 4, "application/json", "bicycle.jpg", "bicycle" },
                    { 5, "application/json", "billiards.jpg", "billiards" },
                    { 6, "application/json", "roadtrip.jpg", "roadtrip" },
                    { 7, "application/json", "running.jpg", "running" },
                    { 8, "application/json", "tennis.jpg", "tennis" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationImages",
                keyColumn: "SportId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ApplicationImages",
                keyColumn: "SportId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ApplicationImages",
                keyColumn: "SportId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ApplicationImages",
                keyColumn: "SportId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ApplicationImages",
                keyColumn: "SportId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ApplicationImages",
                keyColumn: "SportId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ApplicationImages",
                keyColumn: "SportId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ApplicationImages",
                keyColumn: "SportId",
                keyValue: 8);
        }
    }
}
