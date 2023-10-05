using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JwtStore.Api.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VARCHAR",
                table: "User",
                newName: "Image");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "User",
                type: "VARCHAR(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "User",
                newName: "VARCHAR");

            migrationBuilder.AlterColumn<string>(
                name: "VARCHAR",
                table: "User",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)",
                oldMaxLength: 255);
        }
    }
}
