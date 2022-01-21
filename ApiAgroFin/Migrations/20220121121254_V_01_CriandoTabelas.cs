using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiAgroFin.Migrations
{
    public partial class V_01_CriandoTabelas : Migration
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_Pessoa_Id",
                table: "Endereco",
                column: "Pessoa_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
