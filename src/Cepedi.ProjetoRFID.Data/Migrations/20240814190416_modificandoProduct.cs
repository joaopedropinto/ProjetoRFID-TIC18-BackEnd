using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepedi.ProjetoRFID.Data.Migrations
{
    /// <inheritdoc />
    public partial class modificandoProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_RfidTag_IdTag",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_IdTag",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IdTag",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "RfidTag",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RfidTag",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "IdTag",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_IdTag",
                table: "Product",
                column: "IdTag");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_RfidTag_IdTag",
                table: "Product",
                column: "IdTag",
                principalTable: "RfidTag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
