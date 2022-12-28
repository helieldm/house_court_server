using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseCourt.Migrations
{
    /// <inheritdoc />
    public partial class Sensors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sensors_Houses_HouseMACAdress",
                table: "Sensors");

            migrationBuilder.RenameColumn(
                name: "SensorName",
                table: "Sensors",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "SensorAverageConsuption",
                table: "Sensors",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "MACAdress",
                table: "Sensors",
                newName: "AverageConsumption");

            migrationBuilder.RenameColumn(
                name: "SensorId",
                table: "Sensors",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "HouseMACAdress",
                table: "Sensors",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sensors_Houses_HouseMACAdress",
                table: "Sensors",
                column: "HouseMACAdress",
                principalTable: "Houses",
                principalColumn: "MACAdress",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sensors_Houses_HouseMACAdress",
                table: "Sensors");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Sensors",
                newName: "SensorName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Sensors",
                newName: "SensorAverageConsuption");

            migrationBuilder.RenameColumn(
                name: "AverageConsumption",
                table: "Sensors",
                newName: "MACAdress");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sensors",
                newName: "SensorId");

            migrationBuilder.AlterColumn<string>(
                name: "HouseMACAdress",
                table: "Sensors",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_Sensors_Houses_HouseMACAdress",
                table: "Sensors",
                column: "HouseMACAdress",
                principalTable: "Houses",
                principalColumn: "MACAdress");
        }
    }
}
