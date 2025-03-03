using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_Order_Id",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_Order_Id",
                table: "OrderItems");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderItem_Id",
                table: "Orders",
                column: "OrderItem_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderItems_OrderItem_Id",
                table: "Orders",
                column: "OrderItem_Id",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderItems_OrderItem_Id",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderItem_Id",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_Order_Id",
                table: "OrderItems",
                column: "Order_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_Order_Id",
                table: "OrderItems",
                column: "Order_Id",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
