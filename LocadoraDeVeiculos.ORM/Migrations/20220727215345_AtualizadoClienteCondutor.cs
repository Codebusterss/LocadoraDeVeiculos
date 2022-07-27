using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.ORM.Migrations
{
    public partial class AtualizadoClienteCondutor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENTE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(300)", nullable: false),
                    CNPJ = table.Column<string>(type: "varchar(300)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(300)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(300)", nullable: false),
                    Email = table.Column<string>(type: "varchar(300)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(300)", nullable: false),
                    PessoaFisica = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CONDUTOR",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(300)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(300)", nullable: false),
                    CNH = table.Column<string>(type: "varchar(300)", nullable: false),
                    ValidadeCNH = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "varchar(300)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(300)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(300)", nullable: false),
                    CondutorCliente = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONDUTOR", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CONDUTOR_CLIENTE_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "CLIENTE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CONDUTOR_ClienteID",
                table: "CONDUTOR",
                column: "ClienteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONDUTOR");

            migrationBuilder.DropTable(
                name: "CLIENTE");
        }
    }
}
