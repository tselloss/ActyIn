using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActyIn.Migrations
{
    /// <inheritdoc />
    public partial class V115 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingInfo_AthletesInfo_AthletesId",
                table: "BookingInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingInfo_ChosenActivityInfo_ChosenActivityId",
                table: "BookingInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingInfo_MatchModels_MatchModelId",
                table: "BookingInfo");

            migrationBuilder.DropIndex(
                name: "IX_BookingInfo_AthletesId",
                table: "BookingInfo");

            migrationBuilder.DropIndex(
                name: "IX_BookingInfo_ChosenActivityId",
                table: "BookingInfo");

            migrationBuilder.DropIndex(
                name: "IX_BookingInfo_MatchModelId",
                table: "BookingInfo");

            migrationBuilder.DropColumn(
                name: "AthletesId",
                table: "BookingInfo");

            migrationBuilder.DropColumn(
                name: "ChosenActivityId",
                table: "BookingInfo");

            migrationBuilder.DropColumn(
                name: "MatchModelId",
                table: "BookingInfo");

            migrationBuilder.AddColumn<int>(
                name: "BookingEntityBookingId",
                table: "MatchModels",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchModels_BookingEntityBookingId",
                table: "MatchModels",
                column: "BookingEntityBookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchModels_BookingInfo_BookingEntityBookingId",
                table: "MatchModels",
                column: "BookingEntityBookingId",
                principalTable: "BookingInfo",
                principalColumn: "BookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchModels_BookingInfo_BookingEntityBookingId",
                table: "MatchModels");

            migrationBuilder.DropIndex(
                name: "IX_MatchModels_BookingEntityBookingId",
                table: "MatchModels");

            migrationBuilder.DropColumn(
                name: "BookingEntityBookingId",
                table: "MatchModels");

            migrationBuilder.AddColumn<int>(
                name: "AthletesId",
                table: "BookingInfo",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChosenActivityId",
                table: "BookingInfo",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MatchModelId",
                table: "BookingInfo",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookingInfo_AthletesId",
                table: "BookingInfo",
                column: "AthletesId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingInfo_ChosenActivityId",
                table: "BookingInfo",
                column: "ChosenActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingInfo_MatchModelId",
                table: "BookingInfo",
                column: "MatchModelId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingInfo_AthletesInfo_AthletesId",
                table: "BookingInfo",
                column: "AthletesId",
                principalTable: "AthletesInfo",
                principalColumn: "AthletesId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingInfo_ChosenActivityInfo_ChosenActivityId",
                table: "BookingInfo",
                column: "ChosenActivityId",
                principalTable: "ChosenActivityInfo",
                principalColumn: "ChosenActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingInfo_MatchModels_MatchModelId",
                table: "BookingInfo",
                column: "MatchModelId",
                principalTable: "MatchModels",
                principalColumn: "MatchModelId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
