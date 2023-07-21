﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UsersModels.DataModels;

#nullable disable

namespace UsersModels.Migrations
{
    [DbContext(typeof(DbUserContext))]
    [Migration("20230721152930_InicialTwo")]
    partial class InicialTwo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DbUserService.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnOrder(1);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnOrder(3);

                    b.Property<string>("Documento")
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnOrder(5);

                    b.Property<DateTimeOffset>("FechaRegistro")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnOrder(7);

                    b.Property<string>("KeyUsuario")
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnOrder(6);

                    b.Property<string>("Nombre")
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnOrder(2);

                    b.Property<string>("TipoDocumento")
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnOrder(4);

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
