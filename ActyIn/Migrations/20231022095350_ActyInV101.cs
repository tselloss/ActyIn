using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActyIn.Migrations
{
    /// <inheritdoc />
    public partial class ActyInV101 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChoosenActivity",
                table: "AthletesInfoEntity",
                newName: "FavoriteActivity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FavoriteActivity",
                table: "AthletesInfoEntity",
                newName: "ChoosenActivity");
        }
    }
}
