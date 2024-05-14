using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActyIn.Migrations
{
    /// <inheritdoc />
    public partial class v12002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_MatchModels_MatchModelId",
                table: "Bookings");

            migrationBuilder.AlterColumn<int>(
                name: "MatchModelId",
                table: "Bookings",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_MatchModels_MatchModelId",
                table: "Bookings",
                column: "MatchModelId",
                principalTable: "MatchModels",
                principalColumn: "MatchModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_MatchModels_MatchModelId",
                table: "Bookings");

            migrationBuilder.AlterColumn<int>(
                name: "MatchModelId",
                table: "Bookings",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_MatchModels_MatchModelId",
                table: "Bookings",
                column: "MatchModelId",
                principalTable: "MatchModels",
                principalColumn: "MatchModelId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
