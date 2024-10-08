using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepedi.ProjetoRFID.Data.Migrations
{
    /// <inheritdoc />
    public partial class RecriandoTabelaEmbalagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Product");
            migrationBuilder.Sql("DELETE FROM Packaging");
            migrationBuilder.DropTable(name: "Packaging");

            migrationBuilder.DropColumn(
                name: "PackingType",
                table: "Product");

            migrationBuilder.AddColumn<Guid>(
                name: "IdPackaging",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Packaging",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packaging", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_IdPackaging",
                table: "Product",
                column: "IdPackaging");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Packaging_IdPackaging",
                table: "Product",
                column: "IdPackaging",
                principalTable: "Packaging",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
               name: "FK_Product_Packaging_IdPackaging",
               table: "Product");

            migrationBuilder.DropTable(
                name: "Packaging");

            migrationBuilder.DropIndex(
                name: "IX_Product_IdPackaging",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IdPackaging",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "PackingType",
                table: "Product",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
