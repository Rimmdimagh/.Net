using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMInfra.Migrations
{
    /// <inheritdoc />
    public partial class fluent1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassenger_flights_FlightsFlightId",
                table: "FlightPassenger");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassenger_passengers_PassengersPassportNumber",
                table: "FlightPassenger");

            migrationBuilder.DropForeignKey(
                name: "FK_flights_planes_PlaneFK",
                table: "flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_planes",
                table: "planes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger");

            migrationBuilder.DropColumn(
                name: "PlaneFK",
                table: "planes");

            migrationBuilder.RenameTable(
                name: "planes",
                newName: "MyPlanes");

            migrationBuilder.RenameTable(
                name: "FlightPassenger",
                newName: "Volpassenger");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "MyPlanes",
                newName: "PlaneCapacity");

            migrationBuilder.RenameIndex(
                name: "IX_FlightPassenger_PassengersPassportNumber",
                table: "Volpassenger",
                newName: "IX_Volpassenger_PassengersPassportNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyPlanes",
                table: "MyPlanes",
                column: "PlaneId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Volpassenger",
                table: "Volpassenger",
                columns: new[] { "FlightsFlightId", "PassengersPassportNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_flights_MyPlanes_PlaneFK",
                table: "flights",
                column: "PlaneFK",
                principalTable: "MyPlanes",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Volpassenger_flights_FlightsFlightId",
                table: "Volpassenger",
                column: "FlightsFlightId",
                principalTable: "flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Volpassenger_passengers_PassengersPassportNumber",
                table: "Volpassenger",
                column: "PassengersPassportNumber",
                principalTable: "passengers",
                principalColumn: "PassportNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_flights_MyPlanes_PlaneFK",
                table: "flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Volpassenger_flights_FlightsFlightId",
                table: "Volpassenger");

            migrationBuilder.DropForeignKey(
                name: "FK_Volpassenger_passengers_PassengersPassportNumber",
                table: "Volpassenger");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Volpassenger",
                table: "Volpassenger");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyPlanes",
                table: "MyPlanes");

            migrationBuilder.RenameTable(
                name: "Volpassenger",
                newName: "FlightPassenger");

            migrationBuilder.RenameTable(
                name: "MyPlanes",
                newName: "planes");

            migrationBuilder.RenameIndex(
                name: "IX_Volpassenger_PassengersPassportNumber",
                table: "FlightPassenger",
                newName: "IX_FlightPassenger_PassengersPassportNumber");

            migrationBuilder.RenameColumn(
                name: "PlaneCapacity",
                table: "planes",
                newName: "Capacity");

            migrationBuilder.AddColumn<int>(
                name: "PlaneFK",
                table: "planes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger",
                columns: new[] { "FlightsFlightId", "PassengersPassportNumber" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_planes",
                table: "planes",
                column: "PlaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassenger_flights_FlightsFlightId",
                table: "FlightPassenger",
                column: "FlightsFlightId",
                principalTable: "flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);

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
    }
}
