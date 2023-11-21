using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiceleBollmannAPI.Migrations
{
    /// <inheritdoc />
    public partial class ImprementandoPontuacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PONTUACAO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nota = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PONTUACAO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PONTUACAO_PRODUTOS_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "PRODUTOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PONTUACAO_USUARIOS_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PONTUACAO_ProdutoId",
                table: "PONTUACAO",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_PONTUACAO_UsuarioId",
                table: "PONTUACAO",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PONTUACAO");
        }
    }
}
