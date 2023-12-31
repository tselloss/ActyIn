using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActyIn.Migrations
{
    /// <inheritdoc />
    public partial class v12344 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
       @"
        DO $$ 
        BEGIN
            IF EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'public' AND table_name = 'Bookings') THEN
                ALTER TABLE ""Bookings"" DROP CONSTRAINT IF EXISTS ""FK_Bookings_AthletesInfo_AthletesId"";
            END IF;
        END $$;
        ");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MatchModels",
                table: "MatchModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChooseActivityInfo",
                table: "ChooseActivityInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AthletesInfo",
                table: "AthletesInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AthleteImageProfile",
                table: "AthleteImageProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationImages",
                table: "ApplicationImages");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_MatchModels",
                table: "MatchModels",
                column: "MatchModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChooseActivityInfo",
                table: "ChooseActivityInfo",
                column: "ChosenActivityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "BookingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AthletesInfo",
                table: "AthletesInfo",
                column: "AthletesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AthleteImageProfile",
                table: "AthleteImageProfile",
                column: "AthleteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationImages",
                table: "ApplicationImages",
                column: "SportId");
        }
    }
}
