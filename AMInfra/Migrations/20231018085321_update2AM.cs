using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMInfra.Migrations
{
    /// <inheritdoc />
    public partial class update2AM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Airline",
                table: "flights",
                newName: "AirlineLogo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AirlineLogo",
                table: "flights",
                newName: "Airline");
        }
    }
}
