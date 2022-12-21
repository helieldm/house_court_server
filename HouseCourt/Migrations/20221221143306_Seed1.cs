using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HouseCourt.Migrations
{
    /// <inheritdoc />
    public partial class Seed1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Readings_TypeReading_TypeId",
                table: "Readings");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeReading_Unit_UnitId",
                table: "TypeReading");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeReading",
                table: "TypeReading");

            migrationBuilder.RenameTable(
                name: "TypeReading",
                newName: "Type");

            migrationBuilder.RenameIndex(
                name: "IX_TypeReading_UnitId",
                table: "Type",
                newName: "IX_Type_UnitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Type",
                table: "Type",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Unit",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "°C" },
                    { 2, "%" }
                });

            migrationBuilder.InsertData(
                table: "Type",
                columns: new[] { "Id", "Name", "UnitId" },
                values: new object[,]
                {
                    { 1, "Temperature", 1 },
                    { 2, "Humidity", 2 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Readings_Type_TypeId",
                table: "Readings",
                column: "TypeId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Type_Unit_UnitId",
                table: "Type",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Readings_Type_TypeId",
                table: "Readings");

            migrationBuilder.DropForeignKey(
                name: "FK_Type_Unit_UnitId",
                table: "Type");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Type",
                table: "Type");

            migrationBuilder.DeleteData(
                table: "Type",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Type",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "Type",
                newName: "TypeReading");

            migrationBuilder.RenameIndex(
                name: "IX_Type_UnitId",
                table: "TypeReading",
                newName: "IX_TypeReading_UnitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeReading",
                table: "TypeReading",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Readings_TypeReading_TypeId",
                table: "Readings",
                column: "TypeId",
                principalTable: "TypeReading",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TypeReading_Unit_UnitId",
                table: "TypeReading",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
