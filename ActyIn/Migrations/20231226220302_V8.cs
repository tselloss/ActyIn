using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActyIn.Migrations
{
    /// <inheritdoc />
    public partial class V8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChosenActivities",
                table: "ChosenActivities");


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

            migrationBuilder.RenameColumn(
                name: "DateOfActivity",
                table: "ChooseActivityInfo",
                newName: "DateTime");

            migrationBuilder.RenameColumn(
                name: "ChosenActivityName",
                table: "ChooseActivityInfo",
                newName: "Activity");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "ChooseActivityInfo",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChooseActivityInfo",
                table: "ChooseActivityInfo",
                column: "ChosenActivityId");


            migrationBuilder.AddPrimaryKey(
                name: "PK_AthleteImageProfile",
                table: "AthleteImageProfile",
                column: "AthleteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChooseActivityInfo",
                table: "ChooseActivityInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AthletesInfo",
                table: "AthletesInfo");

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

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "ChosenActivities",
                newName: "DateOfActivity");

            migrationBuilder.RenameColumn(
                name: "Activity",
                table: "ChosenActivities",
                newName: "ChosenActivityName");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "ChosenActivities",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChosenActivities",
                table: "ChosenActivities",
                column: "ChosenActivityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Athletes",
                table: "Athletes",
                column: "AthletesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AthleteImageProfiles",
                table: "AthleteImageProfiles",
                column: "AthleteId");
        }
    }
}
