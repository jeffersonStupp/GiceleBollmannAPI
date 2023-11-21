using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiceleBollmannAPI.Migrations
{
    /// <inheritdoc />
    public partial class Recuperando : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nota",
                table: "PRODUTOS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Nota",
                table: "PRODUTOS",
                type: "int",
                nullable: true);
        }
    }
}
