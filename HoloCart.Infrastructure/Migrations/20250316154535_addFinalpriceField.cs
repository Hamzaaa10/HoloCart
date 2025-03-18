using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoloCart.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addFinalpriceField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "FinalPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalPrice",
                table: "Products");
        }
    }
}
