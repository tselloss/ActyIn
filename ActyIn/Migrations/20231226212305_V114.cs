using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActyIn.Migrations
{
    /// <inheritdoc />
    public partial class V114 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AthletesInfo_AthletesId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_ChooseActivityInfo_ChosenActivityId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_MatchModels_MatchModelId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_ChooseActivityInfo_AthletesInfo_AthletesEntityAthletesId",
                table: "ChooseActivityInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ChooseActivityInfo_MatchModels_MatchModelEntityMatchModelId",
                table: "ChooseActivityInfo");

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

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_MatchModelId",
                table: "BookingInfo",
                newName: "IX_BookingInfo_MatchModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_ChosenActivityId",
                table: "BookingInfo",
                newName: "IX_BookingInfo_ChosenActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_AthletesId",
                table: "BookingInfo",
                newName: "IX_BookingInfo_AthletesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChosenActivityInfo",
                table: "ChosenActivityInfo",
                column: "ChosenActivityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingInfo",
                table: "BookingInfo",
                column: "BookingId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_ChosenActivityInfo_AthletesInfo_AthletesEntityAthletesId",
                table: "ChosenActivityInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ChosenActivityInfo_MatchModels_MatchModelEntityMatchModelId",
                table: "ChosenActivityInfo");

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

            migrationBuilder.RenameIndex(
                name: "IX_BookingInfo_MatchModelId",
                table: "Bookings",
                newName: "IX_Bookings_MatchModelId");

            migrationBuilder.RenameIndex(
                name: "IX_BookingInfo_ChosenActivityId",
                table: "Bookings",
                newName: "IX_Bookings_ChosenActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_BookingInfo_AthletesId",
                table: "Bookings",
                newName: "IX_Bookings_AthletesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChooseActivityInfo",
                table: "ChooseActivityInfo",
                column: "ChosenActivityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AthletesInfo_AthletesId",
                table: "Bookings",
                column: "AthletesId",
                principalTable: "AthletesInfo",
                principalColumn: "AthletesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_ChooseActivityInfo_ChosenActivityId",
                table: "Bookings",
                column: "ChosenActivityId",
                principalTable: "ChooseActivityInfo",
                principalColumn: "ChosenActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_MatchModels_MatchModelId",
                table: "Bookings",
                column: "MatchModelId",
                principalTable: "MatchModels",
                principalColumn: "MatchModelId",
                onDelete: ReferentialAction.Cascade);

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
        }
    }
}
