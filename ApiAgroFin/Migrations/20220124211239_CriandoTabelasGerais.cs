﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiAgroFin.Migrations
{
    public partial class CriandoTabelasGerais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Pessoa_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pessoa_Numero_Identificador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pessoa_Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Pessoa_Id);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Endereco_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Endereco_Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco_Numero = table.Column<int>(type: "int", nullable: false),
                    Endereco_Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco_Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco_Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco_Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco_Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Pessoa_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Endereco_Id);
                    table.ForeignKey(
                        name: "FK_Endereco_Pessoa_Pessoa_Id",
                        column: x => x.Pessoa_Id,
                        principalTable: "Pessoa",
                        principalColumn: "Pessoa_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pessoa_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagador_Pessoa_Pessoa_Id",
                        column: x => x.Pessoa_Id,
                        principalTable: "Pessoa",
                        principalColumn: "Pessoa_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recebedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pessoa_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recebedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recebedor_Pessoa_Pessoa_Id",
                        column: x => x.Pessoa_Id,
                        principalTable: "Pessoa",
                        principalColumn: "Pessoa_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Titulo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo_Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Titulo_Valor = table.Column<double>(type: "float", nullable: false),
                    Titulo_Status = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Titulo_Valor_Extenso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titulo_Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PagadorId = table.Column<int>(type: "int", nullable: true),
                    RecebedorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titulo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Titulo_Pagador_PagadorId",
                        column: x => x.PagadorId,
                        principalTable: "Pagador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Titulo_Recebedor_RecebedorId",
                        column: x => x.RecebedorId,
                        principalTable: "Recebedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_Pessoa_Id",
                table: "Endereco",
                column: "Pessoa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pagador_Pessoa_Id",
                table: "Pagador",
                column: "Pessoa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Recebedor_Pessoa_Id",
                table: "Recebedor",
                column: "Pessoa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Titulo_PagadorId",
                table: "Titulo",
                column: "PagadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Titulo_RecebedorId",
                table: "Titulo",
                column: "RecebedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Titulo");

            migrationBuilder.DropTable(
                name: "Pagador");

            migrationBuilder.DropTable(
                name: "Recebedor");

            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
