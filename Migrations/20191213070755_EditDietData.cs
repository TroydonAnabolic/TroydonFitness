using Microsoft.EntityFrameworkCore.Migrations;

namespace TroydonFitness.Migrations
{
    public partial class EditDietData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DietID",
                table: "Product",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DietID",
                table: "Product");
        }
    }
}
