using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class mig_test4_CHANGE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Test4s",
                newName: "Name2");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Test4s",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Test4s");

            migrationBuilder.RenameColumn(
                name: "Name2",
                table: "Test4s",
                newName: "Name");
        }
    }
}
