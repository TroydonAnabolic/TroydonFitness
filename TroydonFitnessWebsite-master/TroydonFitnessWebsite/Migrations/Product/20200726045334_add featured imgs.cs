using Microsoft.EntityFrameworkCore.Migrations;

namespace TroydonFitnessWebsite.Migrations.Product
{
    public partial class addfeaturedimgs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFeatured",
                table: "Product");

            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "PersonalTraining",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFeatured",
                table: "PersonalTraining");

            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
