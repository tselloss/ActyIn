using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActyIn.Migrations
{
    /// <inheritdoc />
    public partial class V109 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfActivity",
                table: "ChooseActivityInfo",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "AthletesId",
                table: "Bookings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChosenActivityId",
                table: "Bookings",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_AthletesId",
                table: "Bookings",
                column: "AthletesId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ChosenActivityId",
                table: "Bookings",
                column: "ChosenActivityId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AthletesInfo_AthletesId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_ChooseActivityInfo_ChosenActivityId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_AthletesId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ChosenActivityId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "DateOfActivity",
                table: "ChooseActivityInfo");

            migrationBuilder.DropColumn(
                name: "AthletesId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ChosenActivityId",
                table: "Bookings");
        }
    }
}
