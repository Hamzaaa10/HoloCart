using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoloCart.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class deleteField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalPrice",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "FinalPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
