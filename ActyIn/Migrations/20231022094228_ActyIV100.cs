using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ActyIn.Migrations
{
    /// <inheritdoc />
    public partial class ActyIV100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AthletesInfoEntity",
                columns: table => new
                {
                    AthletesId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    Address = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    PostalCode = table.Column<int>(type: "integer", nullable: false),
                    ChoosenActivity = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AthletesInfoEntity", x => x.AthletesId);
                });

            migrationBuilder.InsertData(
                table: "AthletesInfoEntity",
                columns: new[] { "AthletesId", "Address", "ChoosenActivity", "City", "Email", "Password", "PostalCode", "Role", "Username" },
                values: new object[] { 1, "123 Main St", "Running", "City1", "user1@example.com", "password1", 12345, 2, "user1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AthletesInfoEntity");
        }
    }
}
