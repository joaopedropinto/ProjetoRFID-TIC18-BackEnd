using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepedi.ProjetoRFID.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIsActiveColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Packaging");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
