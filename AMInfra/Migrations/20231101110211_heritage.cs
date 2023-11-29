using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMInfra.Migrations
{
    /// <inheritdoc />
    public partial class heritage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "passengers");

            migrationBuilder.DropColumn(
                name: "EmployementDate",
                table: "passengers");

            migrationBuilder.DropColumn(
                name: "Function",
                table: "passengers");

            migrationBuilder.DropColumn(
                name: "HealthInformation",
                table: "passengers");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "passengers");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "passengers");

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    PassportNumber = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Function = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployementDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Salary = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.PassportNumber);
                    table.ForeignKey(
                        name: "FK_Staffs_passengers_PassportNumber",
                        column: x => x.PassportNumber,
                        principalTable: "passengers",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ticket",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    classe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    destination = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticket", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "travellers",
                columns: table => new
                {
                    PassportNumber = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    HealthInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_travellers", x => x.PassportNumber);
                    table.ForeignKey(
                        name: "FK_travellers_passengers_PassportNumber",
                        column: x => x.PassportNumber,
                        principalTable: "passengers",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reservations",
                columns: table => new
                {
                    DateReservation = table.Column<DateTime>(type: "Date", nullable: false),
                    passengerFK = table.Column<string>(type: "nvarchar(7)", nullable: false),
                    ticketFK = table.Column<int>(type: "int", nullable: false),
                    prix = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations", x => new { x.passengerFK, x.ticketFK, x.DateReservation });
                    table.ForeignKey(
                        name: "FK_reservations_passengers_passengerFK",
                        column: x => x.passengerFK,
                        principalTable: "passengers",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservations_ticket_ticketFK",
                        column: x => x.ticketFK,
                        principalTable: "ticket",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reservations_ticketFK",
                table: "reservations",
                column: "ticketFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservations");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "travellers");

            migrationBuilder.DropTable(
                name: "ticket");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "passengers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EmployementDate",
                table: "passengers",
                type: "Date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Function",
                table: "passengers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HealthInformation",
                table: "passengers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "passengers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Salary",
                table: "passengers",
                type: "real",
                nullable: true);
        }
    }
}
