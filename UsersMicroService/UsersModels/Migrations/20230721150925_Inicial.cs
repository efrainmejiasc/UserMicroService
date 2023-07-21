using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace UsersModels.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Apellido = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    TipoDocumento = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Documento = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    KeyUsuario = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
