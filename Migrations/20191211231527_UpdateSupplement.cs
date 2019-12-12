using Microsoft.EntityFrameworkCore.Migrations;

namespace TroydonFitness.Migrations
{
    public partial class UpdateSupplement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplement_Product_ProductID",
                table: "Supplement");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Supplement",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplement_Product_ProductID",
                table: "Supplement",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplement_Product_ProductID",
                table: "Supplement");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Supplement",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Supplement_Product_ProductID",
                table: "Supplement",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
