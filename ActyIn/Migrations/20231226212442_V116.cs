using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActyIn.Migrations
{
    /// <inheritdoc />
    public partial class V116 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChosenActivityInfo_AthletesInfo_AthletesEntityAthletesId",
                table: "ChosenActivityInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ChosenActivityInfo_MatchModels_MatchModelEntityMatchModelId",
                table: "ChosenActivityInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchModels_BookingInfo_BookingEntityBookingId",
                table: "MatchModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChosenActivityInfo",
                table: "ChosenActivityInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingInfo",
                table: "BookingInfo");

            migrationBuilder.RenameTable(
                name: "ChosenActivityInfo",
                newName: "ChooseActivityInfo");

            migrationBuilder.RenameTable(
                name: "BookingInfo",
                newName: "Bookings");

            migrationBuilder.RenameIndex(
                name: "IX_ChosenActivityInfo_MatchModelEntityMatchModelId",
                table: "ChooseActivityInfo",
                newName: "IX_ChooseActivityInfo_MatchModelEntityMatchModelId");

            migrationBuilder.RenameIndex(
                name: "IX_ChosenActivityInfo_AthletesEntityAthletesId",
                table: "ChooseActivityInfo",
                newName: "IX_ChooseActivityInfo_AthletesEntityAthletesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChooseActivityInfo",
                table: "ChooseActivityInfo",
                column: "ChosenActivityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChooseActivityInfo_AthletesInfo_AthletesEntityAthletesId",
                table: "ChooseActivityInfo",
                column: "AthletesEntityAthletesId",
                principalTable: "AthletesInfo",
                principalColumn: "AthletesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChooseActivityInfo_MatchModels_MatchModelEntityMatchModelId",
                table: "ChooseActivityInfo",
                column: "MatchModelEntityMatchModelId",
                principalTable: "MatchModels",
                principalColumn: "MatchModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchModels_Bookings_BookingEntityBookingId",
                table: "MatchModels",
                column: "BookingEntityBookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChooseActivityInfo_AthletesInfo_AthletesEntityAthletesId",
                table: "ChooseActivityInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ChooseActivityInfo_MatchModels_MatchModelEntityMatchModelId",
                table: "ChooseActivityInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchModels_Bookings_BookingEntityBookingId",
                table: "MatchModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChooseActivityInfo",
                table: "ChooseActivityInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "ChooseActivityInfo",
                newName: "ChosenActivityInfo");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "BookingInfo");

            migrationBuilder.RenameIndex(
                name: "IX_ChooseActivityInfo_MatchModelEntityMatchModelId",
                table: "ChosenActivityInfo",
                newName: "IX_ChosenActivityInfo_MatchModelEntityMatchModelId");

            migrationBuilder.RenameIndex(
                name: "IX_ChooseActivityInfo_AthletesEntityAthletesId",
                table: "ChosenActivityInfo",
                newName: "IX_ChosenActivityInfo_AthletesEntityAthletesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChosenActivityInfo",
                table: "ChosenActivityInfo",
                column: "ChosenActivityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingInfo",
                table: "BookingInfo",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChosenActivityInfo_AthletesInfo_AthletesEntityAthletesId",
                table: "ChosenActivityInfo",
                column: "AthletesEntityAthletesId",
                principalTable: "AthletesInfo",
                principalColumn: "AthletesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChosenActivityInfo_MatchModels_MatchModelEntityMatchModelId",
                table: "ChosenActivityInfo",
                column: "MatchModelEntityMatchModelId",
                principalTable: "MatchModels",
                principalColumn: "MatchModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchModels_BookingInfo_BookingEntityBookingId",
                table: "MatchModels",
                column: "BookingEntityBookingId",
                principalTable: "BookingInfo",
                principalColumn: "BookingId");
        }
    }
}
