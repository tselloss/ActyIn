using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ActyIn.Migrations
{
    /// <inheritdoc />
    public partial class v303 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationImages",
                columns: table => new
                {
                    SportId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SportName = table.Column<string>(type: "text", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    ContentType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationImages", x => x.SportId);
                });

            migrationBuilder.CreateTable(
                name: "AthleteImageProfile",
                columns: table => new
                {
                    AthleteId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AthleteName = table.Column<string>(type: "text", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    ContentType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AthleteImageProfile", x => x.AthleteId);
                });

            migrationBuilder.CreateTable(
                name: "AthletesInfo",
                columns: table => new
                {
                    AthletesId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    FavoriteActivity = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    PostalCode = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AthletesInfo", x => x.AthletesId);
                });

            migrationBuilder.CreateTable(
                name: "ChooseActivityInfo",
                columns: table => new
                {
                    ChosenActivityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Activity = table.Column<string>(type: "text", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChooseActivityInfo", x => x.ChosenActivityId);
                });

            migrationBuilder.CreateTable(
                name: "MatchModels",
                columns: table => new
                {
                    MatchModelId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LikeThePotentialAthlete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchModels", x => x.MatchModelId);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsernamePicker = table.Column<string>(type: "text", nullable: false),
                    UsernameSelected = table.Column<string>(type: "text", nullable: false),
                    SelectedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ActivityName = table.Column<string>(type: "text", nullable: false),
                    IsCanceled = table.Column<bool>(type: "boolean", nullable: false),
                    MatchModelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_MatchModels_MatchModelId",
                        column: x => x.MatchModelId,
                        principalTable: "MatchModels",
                        principalColumn: "MatchModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_MatchModelId",
                table: "Bookings",
                column: "MatchModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationImages");

            migrationBuilder.DropTable(
                name: "AthleteImageProfile");

            migrationBuilder.DropTable(
                name: "AthletesInfo");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "ChooseActivityInfo");

            migrationBuilder.DropTable(
                name: "MatchModels");
        }
    }
}
