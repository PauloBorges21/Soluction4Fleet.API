using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Soluction4Fleet.API.Migrations
{
    /// <inheritdoc />
    public partial class NovaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locadoras_Enderecos_EnderecoId",
                table: "Locadoras");

            migrationBuilder.DropForeignKey(
                name: "FK_Modelo_Montadoras_MontadoraId",
                table: "Modelo");

            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Modelo_ModeloId",
                table: "Veiculos");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Veiculos",
                table: "Veiculos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Montadoras",
                table: "Montadoras");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locadoras",
                table: "Locadoras");

            migrationBuilder.DropIndex(
                name: "IX_Locadoras_EnderecoId",
                table: "Locadoras");

            migrationBuilder.RenameTable(
                name: "Veiculos",
                newName: "Veiculo");

            migrationBuilder.RenameTable(
                name: "Montadoras",
                newName: "Montadora");

            migrationBuilder.RenameTable(
                name: "Locadoras",
                newName: "Locadora");

            migrationBuilder.RenameIndex(
                name: "IX_Veiculos_ModeloId",
                table: "Veiculo",
                newName: "IX_Veiculo_ModeloId");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Modelo",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Modelo",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Veiculo",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Fabricante",
                table: "Veiculo",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Veiculo",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Cor",
                table: "Veiculo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Chassi",
                table: "Veiculo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Veiculo",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Montadora",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Montadora",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "RazaoSocial",
                table: "Locadora",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NomeFantasia",
                table: "Locadora",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Locadora",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Locadora",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Bairro",
                table: "Locadora",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Cep",
                table: "Locadora",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Cidade",
                table: "Locadora",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Estado",
                table: "Locadora",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Numero",
                table: "Locadora",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Rua",
                table: "Locadora",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Veiculo",
                table: "Veiculo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Montadora",
                table: "Montadora",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locadora",
                table: "Locadora",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Modelo_Nome_MontadoraId",
                table: "Modelo",
                columns: new[] { "Nome", "MontadoraId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_Placa_Chassi",
                table: "Veiculo",
                columns: new[] { "Placa", "Chassi" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Montadora_Nome",
                table: "Montadora",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locadora_Cnpj",
                table: "Locadora",
                column: "Cnpj",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Modelo_Montadora_MontadoraId",
                table: "Modelo",
                column: "MontadoraId",
                principalTable: "Montadora",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculo_Modelo_ModeloId",
                table: "Veiculo",
                column: "ModeloId",
                principalTable: "Modelo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modelo_Montadora_MontadoraId",
                table: "Modelo");

            migrationBuilder.DropForeignKey(
                name: "FK_Veiculo_Modelo_ModeloId",
                table: "Veiculo");

            migrationBuilder.DropIndex(
                name: "IX_Modelo_Nome_MontadoraId",
                table: "Modelo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Veiculo",
                table: "Veiculo");

            migrationBuilder.DropIndex(
                name: "IX_Veiculo_Placa_Chassi",
                table: "Veiculo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Montadora",
                table: "Montadora");

            migrationBuilder.DropIndex(
                name: "IX_Montadora_Nome",
                table: "Montadora");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locadora",
                table: "Locadora");

            migrationBuilder.DropIndex(
                name: "IX_Locadora_Cnpj",
                table: "Locadora");

            migrationBuilder.DropColumn(
                name: "Endereco_Bairro",
                table: "Locadora");

            migrationBuilder.DropColumn(
                name: "Endereco_Cep",
                table: "Locadora");

            migrationBuilder.DropColumn(
                name: "Endereco_Cidade",
                table: "Locadora");

            migrationBuilder.DropColumn(
                name: "Endereco_Estado",
                table: "Locadora");

            migrationBuilder.DropColumn(
                name: "Endereco_Numero",
                table: "Locadora");

            migrationBuilder.DropColumn(
                name: "Endereco_Rua",
                table: "Locadora");

            migrationBuilder.RenameTable(
                name: "Veiculo",
                newName: "Veiculos");

            migrationBuilder.RenameTable(
                name: "Montadora",
                newName: "Montadoras");

            migrationBuilder.RenameTable(
                name: "Locadora",
                newName: "Locadoras");

            migrationBuilder.RenameIndex(
                name: "IX_Veiculo_ModeloId",
                table: "Veiculos",
                newName: "IX_Veiculos_ModeloId");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Modelo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Modelo",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Veiculos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Fabricante",
                table: "Veiculos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Veiculos",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<string>(
                name: "Cor",
                table: "Veiculos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Chassi",
                table: "Veiculos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Veiculos",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Montadoras",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Montadoras",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "RazaoSocial",
                table: "Locadoras",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "NomeFantasia",
                table: "Locadoras",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Locadoras",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Locadoras",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Veiculos",
                table: "Veiculos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Montadoras",
                table: "Montadoras",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locadoras",
                table: "Locadoras",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locadoras_EnderecoId",
                table: "Locadoras",
                column: "EnderecoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Locadoras_Enderecos_EnderecoId",
                table: "Locadoras",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Modelo_Montadoras_MontadoraId",
                table: "Modelo",
                column: "MontadoraId",
                principalTable: "Montadoras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Modelo_ModeloId",
                table: "Veiculos",
                column: "ModeloId",
                principalTable: "Modelo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
