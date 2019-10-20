using Microsoft.EntityFrameworkCore.Migrations;

namespace TroydonFitness.Migrations
{
    public partial class ProductInitialSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ExperienceLevel",
                table: "PersonalTraiing",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PersonalTraiing",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PTSessionName",
                table: "PersonalTraiing",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PTTitle",
                table: "PersonalTraiing",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "PersonalTraiing");

            migrationBuilder.DropColumn(
                name: "PTSessionName",
                table: "PersonalTraiing");

            migrationBuilder.DropColumn(
                name: "PTTitle",
                table: "PersonalTraiing");

            migrationBuilder.AlterColumn<string>(
                name: "ExperienceLevel",
                table: "PersonalTraiing",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
