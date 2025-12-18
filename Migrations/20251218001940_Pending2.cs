using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaFinal213.Migrations
{
    /// <inheritdoc />
    public partial class Pending2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employee_ApplicationUserId",
                table: "Employee");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Employee",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ApplicationUserId",
                table: "Employee",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employee_ApplicationUserId",
                table: "Employee");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Employee",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ApplicationUserId",
                table: "Employee",
                column: "ApplicationUserId",
                unique: true);
        }
    }
}
