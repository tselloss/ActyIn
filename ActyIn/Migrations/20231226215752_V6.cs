using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActyIn.Migrations
{
    /// <inheritdoc />
    public partial class V6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChooseActivityInfo",
                table: "ChooseActivityInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AthleteImageProfile",
                table: "AthleteImageProfile");

            migrationBuilder.RenameTable(
                name: "ChooseActivityInfo",
                newName: "ChosenActivities");

            migrationBuilder.RenameTable(
                name: "AthletesInfo",
                newName: "Athletes");

            migrationBuilder.RenameTable(
                name: "AthleteImageProfile",
                newName: "AthleteImageProfiles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChosenActivities",
                table: "ChosenActivities",
                column: "ChosenActivityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AthleteImageProfiles",
                table: "AthleteImageProfiles",
                column: "AthleteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChosenActivities",
                table: "ChosenActivities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Athletes",
                table: "Athletes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AthleteImageProfiles",
                table: "AthleteImageProfiles");

            migrationBuilder.RenameTable(
                name: "ChosenActivities",
                newName: "ChooseActivityInfo");

            migrationBuilder.RenameTable(
                name: "Athletes",
                newName: "AthletesInfo");

            migrationBuilder.RenameTable(
                name: "AthleteImageProfiles",
                newName: "AthleteImageProfile");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChooseActivityInfo",
                table: "ChooseActivityInfo",
                column: "ChosenActivityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AthletesInfo",
                table: "AthletesInfo",
                column: "AthletesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AthleteImageProfile",
                table: "AthleteImageProfile",
                column: "AthleteId");
        }
    }
}
