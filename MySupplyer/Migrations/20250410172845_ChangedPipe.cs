using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySupplyer.Migrations
{
    /// <inheritdoc />
    public partial class ChangedPipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Pipes",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "PN",
                table: "Pipes",
                newName: "Diametr");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Pipes",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "Diametr",
                table: "Pipes",
                newName: "PN");
        }
    }
}
