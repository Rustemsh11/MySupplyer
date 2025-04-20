using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySupplyer.Migrations
{
    /// <inheritdoc />
    public partial class warehouses2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PipeWarehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PipeId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipeWarehouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PipeWarehouses_Pipes_PipeId",
                        column: x => x.PipeId,
                        principalTable: "Pipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        name: "FK_WarehousePipes_Pipes_PipeId",
                        column: x => x.PipeId,
                        principalTable: "Pipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarehousePipes_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PipeWarehouses_PipeId",
                table: "PipeWarehouses",
                column: "PipeId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehousePipes_PipeId",
                table: "WarehousePipes",
                column: "PipeId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehousePipes_WarehouseId",
                table: "WarehousePipes",
                column: "WarehouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PipeWarehouses");

            migrationBuilder.DropTable(
                name: "WarehousePipes");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
