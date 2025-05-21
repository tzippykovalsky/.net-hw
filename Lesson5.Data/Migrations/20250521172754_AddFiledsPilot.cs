using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lesson5.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFiledsPilot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Pilots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IdentityNumber",
                table: "Pilots",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Pilots");

            migrationBuilder.DropColumn(
                name: "IdentityNumber",
                table: "Pilots");
        }
    }
}
