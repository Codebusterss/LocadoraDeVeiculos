using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.ORM.Migrations
{
    public partial class CriandoTabelas100Atualizado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FUNCIONARIO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(300)", nullable: false),
                    Login = table.Column<string>(type: "varchar(300)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(300)", nullable: false),
                    Salario = table.Column<float>(type: "real", nullable: false),
                    Admin = table.Column<bool>(type: "bit", nullable: false),
                    DataAdmissao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FUNCIONARIO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GRUPODEVEICULOS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRUPODEVEICULOS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PLANODECOBRANCA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoDeVeiculosID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiarioValorDia = table.Column<double>(type: "float", nullable: false),
                    DiarioValorKM = table.Column<double>(type: "float", nullable: false),
                    LivreValorDia = table.Column<double>(type: "float", nullable: false),
                    ControladoValorDia = table.Column<double>(type: "float", nullable: false),
                    ControladoLimiteKM = table.Column<double>(type: "float", nullable: false),
                    ControladoValorKM = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLANODECOBRANCA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PLANODECOBRANCA_GRUPODEVEICULOS_GrupoDeVeiculosID",
                        column: x => x.GrupoDeVeiculosID,
                        principalTable: "GRUPODEVEICULOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VEICULO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Modelo = table.Column<string>(type: "varchar(300)", nullable: false),
                    Marca = table.Column<string>(type: "varchar(300)", nullable: false),
                    Placa = table.Column<string>(type: "varchar(300)", nullable: false),
                    Cor = table.Column<string>(type: "varchar(300)", nullable: false),
                    CapacidadeDoTanque = table.Column<double>(type: "float", nullable: false),
                    KmPercorrido = table.Column<double>(type: "float", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    TipoCombustivel = table.Column<string>(type: "varchar(300)", nullable: false),
                    GrupoDeVeiculoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEICULO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VEICULO_GRUPODEVEICULOS_GrupoDeVeiculoID",
                        column: x => x.GrupoDeVeiculoID,
                        principalTable: "GRUPODEVEICULOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PLANODECOBRANCA_GrupoDeVeiculosID",
                table: "PLANODECOBRANCA",
                column: "GrupoDeVeiculosID");

            migrationBuilder.CreateIndex(
                name: "IX_VEICULO_GrupoDeVeiculoID",
                table: "VEICULO",
                column: "GrupoDeVeiculoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FUNCIONARIO");

            migrationBuilder.DropTable(
                name: "PLANODECOBRANCA");

            migrationBuilder.DropTable(
                name: "VEICULO");

            migrationBuilder.DropTable(
                name: "GRUPODEVEICULOS");
        }
    }
}
