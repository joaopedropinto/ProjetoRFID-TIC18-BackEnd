using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepedi.ProjetoRFID.Data.Migrations
{
    /// <inheritdoc />
    public partial class TrocandoParaListaDeTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Readout_Product_ProductId",
                table: "Readout");

            migrationBuilder.DropIndex(
                name: "IX_Readout_ProductId",
                table: "Readout");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Readout");

            migrationBuilder.RenameColumn(
                name: "Products",
                table: "Readout",
                newName: "Tags");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tags",
                table: "Readout",
                newName: "Products");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Readout",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Readout_ProductId",
                table: "Readout",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Readout_Product_ProductId",
                table: "Readout",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");
        }
    }
}
