using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace UsersModels.Migrations
{
    public partial class Intermedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioAcceso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Password = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioAcceso", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UsuarioAcceso",
                columns: new[] { "Id", "Email", "Password", "Username" },
                values: new object[] { 1, "admin@example.com", "admin", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Documento",
                table: "Usuario",
                column: "Documento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_KeyUsuario",
                table: "Usuario",
                column: "KeyUsuario",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioAcceso");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_Documento",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_KeyUsuario",
                table: "Usuario");
        }
    }
}
