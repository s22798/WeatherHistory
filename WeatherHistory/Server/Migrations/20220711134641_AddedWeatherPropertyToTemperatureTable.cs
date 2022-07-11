using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherHistory.Server.Migrations
{
    public partial class AddedWeatherPropertyToTemperatureTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Temperatures_Weathers_IdWeather",
                table: "Temperatures");

            migrationBuilder.DropTable(
                name: "Weathers");

            migrationBuilder.DropIndex(
                name: "IX_Temperatures_IdWeather",
                table: "Temperatures");

            migrationBuilder.DropColumn(
                name: "IdWeather",
                table: "Temperatures");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Temperatures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "WeatherName",
                table: "Temperatures",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Temperatures");

            migrationBuilder.DropColumn(
                name: "WeatherName",
                table: "Temperatures");

            migrationBuilder.AddColumn<int>(
                name: "IdWeather",
                table: "Temperatures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Weathers",
                columns: table => new
                {
                    IdWeather = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weathers", x => x.IdWeather);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Temperatures_IdWeather",
                table: "Temperatures",
                column: "IdWeather");

            migrationBuilder.AddForeignKey(
                name: "FK_Temperatures_Weathers_IdWeather",
                table: "Temperatures",
                column: "IdWeather",
                principalTable: "Weathers",
                principalColumn: "IdWeather",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
