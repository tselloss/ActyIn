using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ActyIn.Migrations
{
    /// <inheritdoc />
    public partial class v110 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AthletesInfo",
                keyColumn: "AthletesId",
                keyValue: 1);

            migrationBuilder.CreateTable(
                name: "MatchModels",
                columns: table => new
                {
                    MatchModelId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LikeThePotentialAthlete = table.Column<bool>(type: "boolean", nullable: false),
                    ChosenActivityId = table.Column<int>(type: "integer", nullable: false)
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
                    MatchModelId = table.Column<int>(type: "integer", nullable: false),
                    IsCanceled = table.Column<bool>(type: "boolean", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "ChooseActivityInfo",
                columns: table => new
                {
                    ChosenActivityId = table.Column<int>(type: "integer", nullable: false),
                    ChosenActivityName = table.Column<string>(type: "text", nullable: false),
                    AthletesEntityId = table.Column<int>(type: "integer", nullable: false),
                    MatchModelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChooseActivityInfo", x => x.ChosenActivityId);
                    table.ForeignKey(
                        name: "FK_ChooseActivityInfo_AthletesInfo_ChosenActivityId",
                        column: x => x.ChosenActivityId,
                        principalTable: "AthletesInfo",
                        principalColumn: "AthletesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChooseActivityInfo_MatchModels_MatchModelId",
                        column: x => x.MatchModelId,
                        principalTable: "MatchModels",
                        principalColumn: "MatchModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_MatchModelId",
                table: "Bookings",
                column: "MatchModelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChooseActivityInfo_MatchModelId",
                table: "ChooseActivityInfo",
                column: "MatchModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "ChooseActivityInfo");

            migrationBuilder.DropTable(
                name: "MatchModels");

            migrationBuilder.InsertData(
                table: "AthletesInfo",
                columns: new[] { "AthletesId", "Address", "City", "Email", "FavoriteActivity", "Password", "PostalCode", "Role", "Username" },
                values: new object[] { 1, "123 Main St", "City1", "user1@example.com", "Running", "password1", 12345, 2, "user1" });
        }
    }
}
