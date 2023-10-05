using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JwtStore.Api.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NVARCHAR",
                table: "User",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "NVARCHAR(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "User",
                newName: "NVARCHAR");

            migrationBuilder.AlterColumn<string>(
                name: "NVARCHAR",
                table: "User",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(120)",
                oldMaxLength: 120);
        }
    }
}
