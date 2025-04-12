using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySupplyer.Migrations
{
    /// <inheritdoc />
    public partial class addGostEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gosts", x => x.Id);
                });

            migrationBuilder.AddColumn<int>(
                name: "GostId",
                table: "Pipes",
                type: "int",
                nullable: true,
                defaultValue: 0);


            migrationBuilder.CreateIndex(
                name: "IX_Pipes_GostId",
                table: "Pipes",
                column: "GostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pipes_Gosts_GostId",
                table: "Pipes",
                column: "GostId",
                principalTable: "Gosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pipes_Gosts_GostId",
                table: "Pipes");

            migrationBuilder.DropTable(
                name: "Gosts");

            migrationBuilder.DropIndex(
                name: "IX_Pipes_GostId",
                table: "Pipes");

            migrationBuilder.DropColumn(
                name: "GostId",
                table: "Pipes");
        }
    }
}
