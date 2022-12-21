using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseCourt.Migrations
{
    /// <inheritdoc />
    public partial class ReadingType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Readings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Readings_TypeId",
                table: "Readings",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Readings_TypeReading_TypeId",
                table: "Readings",
                column: "TypeId",
                principalTable: "TypeReading",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Readings_TypeReading_TypeId",
                table: "Readings");

            migrationBuilder.DropIndex(
                name: "IX_Readings_TypeId",
                table: "Readings");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Readings");
        }
    }
}
