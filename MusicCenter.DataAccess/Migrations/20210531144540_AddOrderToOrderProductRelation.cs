﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicCenter.EfDataAccess.Migrations
{
    public partial class AddOrderToOrderProductRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Orders_OrderId",
                table: "OrderProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Orders_OrderId",
                table: "OrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderProducts");
        }
    }
}
