using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsersModels.Migrations
{
    public partial class InicialTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "FechaRegistro",
                table: "Usuario",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaRegistro",
                table: "Usuario",
                type: "TIMESTAMP",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");
        }
    }
}
