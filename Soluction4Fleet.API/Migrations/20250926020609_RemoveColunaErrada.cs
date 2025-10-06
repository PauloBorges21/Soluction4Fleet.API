using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Soluction4Fleet.API.Migrations
{
    /// <inheritdoc />
    public partial class RemoveColunaErrada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Locadora");
            // Já removido manualmente no banco
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EnderecoId",
                table: "Locadora",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
            // Já removido manualmente no banco
        }
    }
}
