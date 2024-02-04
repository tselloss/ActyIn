using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActyIn.Migrations
{
    /// <inheritdoc />
    public partial class v401 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AthletesId",
                table: "Bookings",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_AthletesId",
                table: "Bookings",
                column: "AthletesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AthletesInfo_AthletesId",
                table: "Bookings",
                column: "AthletesId",
                principalTable: "AthletesInfo",
                principalColumn: "AthletesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AthletesInfo_AthletesId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_AthletesId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "AthletesId",
                table: "Bookings");
        }
    }
}
