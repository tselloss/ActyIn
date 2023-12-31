using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActyIn.Migrations
{
    /// <inheritdoc />
    public partial class V112 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChooseActivityInfo_AthletesInfo_AthletesEntityId",
                table: "ChooseActivityInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ChooseActivityInfo_MatchModels_MatchModelId",
                table: "ChooseActivityInfo");

            migrationBuilder.DropIndex(
                name: "IX_ChooseActivityInfo_AthletesEntityId",
                table: "ChooseActivityInfo");

            migrationBuilder.DropIndex(
                name: "IX_ChooseActivityInfo_MatchModelId",
                table: "ChooseActivityInfo");

            migrationBuilder.DropColumn(
                name: "AthletesEntityId",
                table: "ChooseActivityInfo");

            migrationBuilder.DropColumn(
                name: "MatchModelId",
                table: "ChooseActivityInfo");

            migrationBuilder.AddColumn<int>(
                name: "AthletesEntityAthletesId",
                table: "ChooseActivityInfo",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MatchModelEntityMatchModelId",
                table: "ChooseActivityInfo",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "ChooseActivityInfo",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChooseActivityInfo_AthletesEntityAthletesId",
                table: "ChooseActivityInfo",
                column: "AthletesEntityAthletesId");

            migrationBuilder.CreateIndex(
                name: "IX_ChooseActivityInfo_MatchModelEntityMatchModelId",
                table: "ChooseActivityInfo",
                column: "MatchModelEntityMatchModelId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChooseActivityInfo_AthletesInfo_AthletesEntityAthletesId",
                table: "ChooseActivityInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ChooseActivityInfo_MatchModels_MatchModelEntityMatchModelId",
                table: "ChooseActivityInfo");

            migrationBuilder.DropIndex(
                name: "IX_ChooseActivityInfo_AthletesEntityAthletesId",
                table: "ChooseActivityInfo");

            migrationBuilder.DropIndex(
                name: "IX_ChooseActivityInfo_MatchModelEntityMatchModelId",
                table: "ChooseActivityInfo");

            migrationBuilder.DropColumn(
                name: "AthletesEntityAthletesId",
                table: "ChooseActivityInfo");

            migrationBuilder.DropColumn(
                name: "MatchModelEntityMatchModelId",
                table: "ChooseActivityInfo");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "ChooseActivityInfo");

            migrationBuilder.AddColumn<int>(
                name: "AthletesEntityId",
                table: "ChooseActivityInfo",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MatchModelId",
                table: "ChooseActivityInfo",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ChooseActivityInfo_AthletesEntityId",
                table: "ChooseActivityInfo",
                column: "AthletesEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ChooseActivityInfo_MatchModelId",
                table: "ChooseActivityInfo",
                column: "MatchModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChooseActivityInfo_AthletesInfo_AthletesEntityId",
                table: "ChooseActivityInfo",
                column: "AthletesEntityId",
                principalTable: "AthletesInfo",
                principalColumn: "AthletesId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChooseActivityInfo_MatchModels_MatchModelId",
                table: "ChooseActivityInfo",
                column: "MatchModelId",
                principalTable: "MatchModels",
                principalColumn: "MatchModelId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
