using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMInfra.Migrations
{
    /// <inheritdoc />
    public partial class Annotation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassenger_passengers_PassengersId",
                table: "FlightPassenger");

            migrationBuilder.DropForeignKey(
                name: "FK_flights_planes_PlaneId",
                table: "flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_passengers",
                table: "passengers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger");

            migrationBuilder.DropIndex(
                name: "IX_FlightPassenger_PassengersId",
                table: "FlightPassenger");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "passengers");

            migrationBuilder.DropColumn(
                name: "PassengersId",
                table: "FlightPassenger");

            migrationBuilder.RenameColumn(
                name: "PlaneId",
                table: "flights",
                newName: "PlaneFK");

            migrationBuilder.RenameIndex(
                name: "IX_flights_PlaneId",
                table: "flights",
                newName: "IX_flights_PlaneFK");

            migrationBuilder.AddColumn<int>(
                name: "PlaneFK",
                table: "planes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PassportNumber",
                table: "passengers",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "passengers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "PassengersPassportNumber",
                table: "FlightPassenger",
                type: "nvarchar(7)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_passengers",
                table: "passengers",
                column: "PassportNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger",
                columns: new[] { "FlightsFlightId", "PassengersPassportNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_FlightPassenger_PassengersPassportNumber",
                table: "FlightPassenger",
                column: "PassengersPassportNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassenger_passengers_PassengersPassportNumber",
                table: "FlightPassenger",
                column: "PassengersPassportNumber",
                principalTable: "passengers",
                principalColumn: "PassportNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_flights_planes_PlaneFK",
                table: "flights",
                column: "PlaneFK",
                principalTable: "planes",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassenger_passengers_PassengersPassportNumber",
                table: "FlightPassenger");

            migrationBuilder.DropForeignKey(
                name: "FK_flights_planes_PlaneFK",
                table: "flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_passengers",
                table: "passengers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger");

            migrationBuilder.DropIndex(
                name: "IX_FlightPassenger_PassengersPassportNumber",
                table: "FlightPassenger");

            migrationBuilder.DropColumn(
                name: "PlaneFK",
                table: "planes");

            migrationBuilder.DropColumn(
                name: "PassengersPassportNumber",
                table: "FlightPassenger");

            migrationBuilder.RenameColumn(
                name: "PlaneFK",
                table: "flights",
                newName: "PlaneId");

            migrationBuilder.RenameIndex(
                name: "IX_flights_PlaneFK",
                table: "flights",
                newName: "IX_flights_PlaneId");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "passengers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "PassportNumber",
                table: "passengers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "passengers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PassengersId",
                table: "FlightPassenger",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_passengers",
                table: "passengers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger",
                columns: new[] { "FlightsFlightId", "PassengersId" });

            migrationBuilder.CreateIndex(
                name: "IX_FlightPassenger_PassengersId",
                table: "FlightPassenger",
                column: "PassengersId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassenger_passengers_PassengersId",
                table: "FlightPassenger",
                column: "PassengersId",
                principalTable: "passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_flights_planes_PlaneId",
                table: "flights",
                column: "PlaneId",
                principalTable: "planes",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
