using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMInfra.Migrations
{
    /// <inheritdoc />
    public partial class fullnameupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "passengers",
                newName: "fullname_LastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "passengers",
                newName: "fullname_FirstName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fullname_LastName",
                table: "passengers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "fullname_FirstName",
                table: "passengers",
                newName: "FirstName");
        }
    }
}
