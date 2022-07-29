using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MartelinhoDeOuro.API.Migrations
{
    public partial class MudancaTabelaServico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Proprietarios_ProprietarioId",
                table: "Servicos");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Veiculos_VeiculoId",
                table: "Servicos");

            migrationBuilder.AlterColumn<Guid>(
                name: "VeiculoId",
                table: "Servicos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProprietarioId",
                table: "Servicos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Proprietarios_ProprietarioId",
                table: "Servicos",
                column: "ProprietarioId",
                principalTable: "Proprietarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Veiculos_VeiculoId",
                table: "Servicos",
                column: "VeiculoId",
                principalTable: "Veiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Proprietarios_ProprietarioId",
                table: "Servicos");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Veiculos_VeiculoId",
                table: "Servicos");

            migrationBuilder.AlterColumn<Guid>(
                name: "VeiculoId",
                table: "Servicos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProprietarioId",
                table: "Servicos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Proprietarios_ProprietarioId",
                table: "Servicos",
                column: "ProprietarioId",
                principalTable: "Proprietarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Veiculos_VeiculoId",
                table: "Servicos",
                column: "VeiculoId",
                principalTable: "Veiculos",
                principalColumn: "Id");
        }
    }
}
