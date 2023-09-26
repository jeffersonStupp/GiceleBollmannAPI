using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GiceleBollmannAPI.Migrations
{
    /// <inheritdoc />
    public partial class UsuarioMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRODUTOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nota = table.Column<int>(type: "int", nullable: true),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Tipo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: "usuario")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "USUARIOS",
                columns: new[] { "Id", "Email", "Nome", "Senha", "Telefone", "Tipo" },
                values: new object[,]
                {
                    { 1, "usuario@email.com", "usuario", "usuario", "(00)00000-0000", "usuario" },
                    { 2, "jeffersonstupp@hotmail.com", "Jefferson", "0411vm", "(47)98811-9538", "administrador" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUTOS");

            migrationBuilder.DropTable(
                name: "USUARIOS");
        }
    }
}
