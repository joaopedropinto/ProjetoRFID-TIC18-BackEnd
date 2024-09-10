using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepedi.ProjetoRFID.Data.Migrations
{
    /// <inheritdoc />
    public partial class adicionandoTagAoProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_RfidTag_IdTag",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_IdTag",
                table: "Product");
        }
    }
}
