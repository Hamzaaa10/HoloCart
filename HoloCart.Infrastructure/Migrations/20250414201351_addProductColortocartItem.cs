using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoloCart.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addProductColortocartItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductColorId",
                table: "CartItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductColorId",
                table: "CartItems",
                column: "ProductColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_ProductColors_ProductColorId",
                table: "CartItems",
                column: "ProductColorId",
                principalTable: "ProductColors",
                principalColumn: "ProductColorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_ProductColors_ProductColorId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_ProductColorId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "ProductColorId",
                table: "CartItems");
        }
    }
}
