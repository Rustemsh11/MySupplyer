using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySupplyer.Migrations
{
    /// <inheritdoc />
    public partial class warehousesTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WarehousePipesId",
                table: "Pipes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarehousePipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    PipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehousePipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarehousePipes_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pipes_WarehousePipesId",
                table: "Pipes",
                column: "WarehousePipesId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehousePipes_WarehouseId",
                table: "WarehousePipes",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pipes_WarehousePipes_WarehousePipesId",
                table: "Pipes",
                column: "WarehousePipesId",
                principalTable: "WarehousePipes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pipes_WarehousePipes_WarehousePipesId",
                table: "Pipes");

            migrationBuilder.DropTable(
                name: "WarehousePipes");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Pipes_WarehousePipesId",
                table: "Pipes");

            migrationBuilder.DropColumn(
                name: "WarehousePipesId",
                table: "Pipes");
        }
    }
}
