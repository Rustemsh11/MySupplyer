﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySupplyer.Migrations
{
    /// <inheritdoc />
    public partial class addedCountField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "WarehousePipes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "WarehousePipes");
        }
    }
}
