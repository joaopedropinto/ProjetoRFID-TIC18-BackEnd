using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepedi.ProjetoRFID.Data.Migrations
{
    /// <inheritdoc />
    public partial class TrocandoIdsEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Apaga todos os dados das tabelas
            migrationBuilder.Sql("DELETE FROM Product;");
            migrationBuilder.Sql("DELETE FROM RfidTag;");
            migrationBuilder.Sql("DELETE FROM Supplier;");
            migrationBuilder.Sql("DELETE FROM Category;");

            // Remover chaves estrangeiras e índices
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Supplier_IdSupplier",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_IdSupplier",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_IdCategory",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_IdCategory",
                table: "Product");

            // Remover chaves primárias
            migrationBuilder.DropPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RfidTag",
                table: "RfidTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            // Supplier
            migrationBuilder.DropColumn(name: "Id", table: "Supplier");
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Supplier",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()");

            // RfidTag
            migrationBuilder.DropColumn(name: "Id", table: "RfidTag");
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "RfidTag",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()");

            // Product
            migrationBuilder.DropColumn(name: "Id", table: "Product");
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()");

            migrationBuilder.AddColumn<Guid>(
                name: "NewIdSupplier",
                table: "Product",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.Sql("UPDATE Product SET NewIdSupplier = NEWID()");

            migrationBuilder.DropColumn(name: "IdSupplier", table: "Product");
            migrationBuilder.RenameColumn(
                name: "NewIdSupplier",
                table: "Product",
                newName: "IdSupplier");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdSupplier",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "NewIdCategory",
                table: "Product",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.Sql("UPDATE Product SET NewIdCategory = NEWID()");

            migrationBuilder.DropColumn(name: "IdCategory", table: "Product");
            migrationBuilder.RenameColumn(
                name: "NewIdCategory",
                table: "Product",
                newName: "IdCategory");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdCategory",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            // Category
            migrationBuilder.DropColumn(name: "Id", table: "Category");
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Category",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()");

            // Recriar chaves primárias
            migrationBuilder.AddPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RfidTag",
                table: "RfidTag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            // Recriar índices
            migrationBuilder.CreateIndex(
                name: "IX_Product_IdSupplier",
                table: "Product",
                column: "IdSupplier");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IdCategory",
                table: "Product",
                column: "IdCategory");

            // Recriar chaves estrangeiras
            migrationBuilder.AddForeignKey(
                name: "FK_Product_Supplier_IdSupplier",
                table: "Product",
                column: "IdSupplier",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_IdCategory",
                table: "Product",
                column: "IdCategory",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Reverter as alterações feitas no método Up
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Supplier_IdSupplier",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_IdCategory",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RfidTag",
                table: "RfidTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Product_IdSupplier",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_IdCategory",
                table: "Product");

            migrationBuilder.DropColumn(name: "Id", table: "Supplier");
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Supplier",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.DropColumn(name: "Id", table: "RfidTag");
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RfidTag",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.DropColumn(name: "Id", table: "Product");
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "IdSupplier",
                table: "Product",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "IdCategory",
                table: "Product",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.DropColumn(name: "Id", table: "Category");
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RfidTag",
                table: "RfidTag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IdSupplier",
                table: "Product",
                column: "IdSupplier");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IdCategory",
                table: "Product",
                column: "IdCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Supplier_IdSupplier",
                table: "Product",
                column: "IdSupplier",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_IdCategory",
                table: "Product",
                column: "IdCategory",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
