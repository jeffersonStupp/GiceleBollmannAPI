using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiceleBollmannAPI.Migrations
{
    /// <inheritdoc />
    public partial class ImplementUserName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "USUARIOS",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserName",
                value: "usuario");

            migrationBuilder.UpdateData(
                table: "USUARIOS",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Nome", "UserName" },
                values: new object[] { "Jefferson Stupp", "stupp" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "USUARIOS");

            migrationBuilder.UpdateData(
                table: "USUARIOS",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nome",
                value: "Jefferson");
        }
    }
}
