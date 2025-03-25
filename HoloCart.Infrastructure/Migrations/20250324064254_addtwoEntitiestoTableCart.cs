using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoloCart.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addtwoEntitiestoTableCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DiscountCode",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPercentage",
                table: "Carts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountCode",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "DiscountPercentage",
                table: "Carts");
        }
    }
}
