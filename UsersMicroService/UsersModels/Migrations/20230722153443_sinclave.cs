using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsersModels.Migrations
{
    public partial class sinclave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuario_Documento",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_KeyUsuario",
                table: "Usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
