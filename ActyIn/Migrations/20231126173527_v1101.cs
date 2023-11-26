using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ActyIn.Migrations
{
    /// <inheritdoc />
    public partial class v1101 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChooseActivityInfo_AthletesInfo_ChosenActivityId",
                table: "ChooseActivityInfo");

            migrationBuilder.AlterColumn<int>(
                name: "ChosenActivityId",
                table: "ChooseActivityInfo",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_ChooseActivityInfo_AthletesEntityId",
                table: "ChooseActivityInfo",
                column: "AthletesEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChooseActivityInfo_AthletesInfo_AthletesEntityId",
                table: "ChooseActivityInfo",
                column: "AthletesEntityId",
                principalTable: "AthletesInfo",
                principalColumn: "AthletesId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChooseActivityInfo_AthletesInfo_AthletesEntityId",
                table: "ChooseActivityInfo");

            migrationBuilder.DropIndex(
                name: "IX_ChooseActivityInfo_AthletesEntityId",
                table: "ChooseActivityInfo");

            migrationBuilder.AlterColumn<int>(
                name: "ChosenActivityId",
                table: "ChooseActivityInfo",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_ChooseActivityInfo_AthletesInfo_ChosenActivityId",
                table: "ChooseActivityInfo",
                column: "ChosenActivityId",
                principalTable: "AthletesInfo",
                principalColumn: "AthletesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
