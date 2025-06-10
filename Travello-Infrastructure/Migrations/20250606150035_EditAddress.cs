using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travello_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Government",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Addresses",
                newName: "Governorate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Governorate",
                table: "Addresses",
                newName: "State");

            migrationBuilder.AddColumn<string>(
                name: "Government",
                table: "Addresses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
