using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Soluction4Fleet.API.Migrations
{
    /// <inheritdoc />
    public partial class CriarFrotaLocadora : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FrotaLocadora",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocadoraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataSaida = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrotaLocadora", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FrotaLocadora_Locadora_LocadoraId",
                        column: x => x.LocadoraId,
                        principalTable: "Locadora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FrotaLocadora_Veiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FrotaLocadora_LocadoraId",
                table: "FrotaLocadora",
                column: "LocadoraId");

            migrationBuilder.CreateIndex(
                name: "IX_FrotaLocadora_VeiculoId",
                table: "FrotaLocadora",
                column: "VeiculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FrotaLocadora");
        }
    }
}
