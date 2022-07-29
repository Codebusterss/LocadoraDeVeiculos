using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.ORM.Migrations
{
    public partial class LocacaoTaxa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TAXA_LOCACAO_LocacaoID",
                table: "TAXA");

            migrationBuilder.DropIndex(
                name: "IX_TAXA_LocacaoID",
                table: "TAXA");

            migrationBuilder.DropColumn(
                name: "LocacaoID",
                table: "TAXA");

            migrationBuilder.CreateTable(
                name: "LocacaoTaxa",
                columns: table => new
                {
                    LocacoesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxasID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocacaoTaxa", x => new { x.LocacoesID, x.TaxasID });
                    table.ForeignKey(
                        name: "FK_LocacaoTaxa_LOCACAO_LocacoesID",
                        column: x => x.LocacoesID,
                        principalTable: "LOCACAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocacaoTaxa_TAXA_TaxasID",
                        column: x => x.TaxasID,
                        principalTable: "TAXA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocacaoTaxa_TaxasID",
                table: "LocacaoTaxa",
                column: "TaxasID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocacaoTaxa");

            migrationBuilder.AddColumn<Guid>(
                name: "LocacaoID",
                table: "TAXA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TAXA_LocacaoID",
                table: "TAXA",
                column: "LocacaoID");

            migrationBuilder.AddForeignKey(
                name: "FK_TAXA_LOCACAO_LocacaoID",
                table: "TAXA",
                column: "LocacaoID",
                principalTable: "LOCACAO",
                principalColumn: "ID");
        }
    }
}
