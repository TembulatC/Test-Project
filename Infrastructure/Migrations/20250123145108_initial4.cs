using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_OrderItems_OrderItem_Id",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_OrderItem_Id",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "OrderItem_Id",
                table: "Items");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_Item_Id",
                table: "OrderItems",
                column: "Item_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Items_Item_Id",
                table: "OrderItems",
                column: "Item_Id",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Items_Item_Id",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_Item_Id",
                table: "OrderItems");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderItem_Id",
                table: "Items",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Items_OrderItem_Id",
                table: "Items",
                column: "OrderItem_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_OrderItems_OrderItem_Id",
                table: "Items",
                column: "OrderItem_Id",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
