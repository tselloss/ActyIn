using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActyIn.Migrations
{
    /// <inheritdoc />
    public partial class v123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Check if the "Bookings" table exists before attempting to drop the foreign key constraint
            if (migrationBuilder.ActiveProvider.ToLower() == "npgsql") // Check if the provider is Npgsql (PostgreSQL)
            {
                migrationBuilder.Sql(
                    @"
            DO $$ 
            BEGIN
                IF EXISTS (SELECT 1 FROM information_schema.tables WHERE table_schema = 'public' AND table_name = 'Bookings') THEN
                    ALTER TABLE ""Bookings"" DROP CONSTRAINT ""FK_Bookings_AthletesInfo_AthletesId"";
                END IF;
            END $$;
            ");
            }
            else
            {
                // For other database providers, just attempt to drop the constraint
                migrationBuilder.DropForeignKey(
                    name: "FK_Bookings_AthletesInfo_AthletesId",
                    table: "Bookings");
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
