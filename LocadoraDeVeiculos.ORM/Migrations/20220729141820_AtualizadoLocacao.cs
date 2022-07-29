using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.ORM.Migrations
{
    public partial class AtualizadoLocacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LocacaoID",
                table: "TAXA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LOCACAO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncionarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CondutorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VeiculoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataLocacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusLocacao = table.Column<string>(type: "varchar(300)", nullable: false),
                    Seguro = table.Column<string>(type: "varchar(300)", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOCACAO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LOCACAO_CLIENTE_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "CLIENTE",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_LOCACAO_CONDUTOR_CondutorID",
                        column: x => x.CondutorID,
                        principalTable: "CONDUTOR",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_LOCACAO_FUNCIONARIO_FuncionarioID",
                        column: x => x.FuncionarioID,
                        principalTable: "FUNCIONARIO",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_LOCACAO_PLANODECOBRANCA_PlanoID",
                        column: x => x.PlanoID,
                        principalTable: "PLANODECOBRANCA",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_LOCACAO_VEICULO_VeiculoID",
                        column: x => x.VeiculoID,
                        principalTable: "VEICULO",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TAXA_LocacaoID",
                table: "TAXA",
                column: "LocacaoID");

            migrationBuilder.CreateIndex(
                name: "IX_LOCACAO_ClienteID",
                table: "LOCACAO",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_LOCACAO_CondutorID",
                table: "LOCACAO",
                column: "CondutorID");

            migrationBuilder.CreateIndex(
                name: "IX_LOCACAO_FuncionarioID",
                table: "LOCACAO",
                column: "FuncionarioID");

            migrationBuilder.CreateIndex(
                name: "IX_LOCACAO_PlanoID",
                table: "LOCACAO",
                column: "PlanoID");

            migrationBuilder.CreateIndex(
                name: "IX_LOCACAO_VeiculoID",
                table: "LOCACAO",
                column: "VeiculoID");

            migrationBuilder.AddForeignKey(
                name: "FK_TAXA_LOCACAO_LocacaoID",
                table: "TAXA",
                column: "LocacaoID",
                principalTable: "LOCACAO",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TAXA_LOCACAO_LocacaoID",
                table: "TAXA");

            migrationBuilder.DropTable(
                name: "LOCACAO");

            migrationBuilder.DropIndex(
                name: "IX_TAXA_LocacaoID",
                table: "TAXA");

            migrationBuilder.DropColumn(
                name: "LocacaoID",
                table: "TAXA");
        }
    }
}
