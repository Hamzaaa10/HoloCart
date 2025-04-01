using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoloCart.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editInProductImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductColors_ProductImages_ProductImageId",
                table: "ProductColors");

            migrationBuilder.DropIndex(
                name: "IX_ProductColors_ProductImageId",
                table: "ProductColors");

            migrationBuilder.AddColumn<int>(
                name: "ProductColorId",
                table: "ProductImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ProductImageId",
                table: "ProductColors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductColorId",
                table: "ProductImages",
                column: "ProductColorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_ProductColors_ProductColorId",
                table: "ProductImages",
                column: "ProductColorId",
                principalTable: "ProductColors",
                principalColumn: "ProductColorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_ProductColors_ProductColorId",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_ProductColorId",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "ProductColorId",
                table: "ProductImages");

            migrationBuilder.AlterColumn<int>(
                name: "ProductImageId",
                table: "ProductColors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductColors_ProductImageId",
                table: "ProductColors",
                column: "ProductImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColors_ProductImages_ProductImageId",
                table: "ProductColors",
                column: "ProductImageId",
                principalTable: "ProductImages",
                principalColumn: "ProductImageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
