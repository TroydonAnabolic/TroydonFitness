using Microsoft.EntityFrameworkCore.Migrations;

namespace TroydonFitness.Migrations
{
    public partial class SeedCustomizedRoutines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomizedRoutine_Product_ProductID",
                table: "CustomizedRoutine");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "CustomizedRoutine",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomizedRoutine_Product_ProductID",
                table: "CustomizedRoutine",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomizedRoutine_Product_ProductID",
                table: "CustomizedRoutine");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "CustomizedRoutine",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_CustomizedRoutine_Product_ProductID",
                table: "CustomizedRoutine",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
