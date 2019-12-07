using Microsoft.EntityFrameworkCore.Migrations;

namespace TroydonFitness.Migrations
{
    public partial class InitialDietContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "TrainingEquipment",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DietID",
                table: "TrainingEquipment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DietId",
                table: "SupplementRoutine",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DietWeight",
                table: "Diet",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "SupplementId",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingEquipment_DietID",
                table: "TrainingEquipment",
                column: "DietID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupplementRoutine_DietId",
                table: "SupplementRoutine",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomizedRoutine_SupplementId",
                table: "CustomizedRoutine",
                column: "SupplementId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomizedRoutine_Supplement_SupplementId",
                table: "CustomizedRoutine",
                column: "SupplementId",
                principalTable: "Supplement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplementRoutine_Diet_DietId",
                table: "SupplementRoutine",
                column: "DietId",
                principalTable: "Diet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingEquipment_Diet_DietID",
                table: "TrainingEquipment",
                column: "DietID",
                principalTable: "Diet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomizedRoutine_Supplement_SupplementId",
                table: "CustomizedRoutine");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplementRoutine_Diet_DietId",
                table: "SupplementRoutine");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingEquipment_Diet_DietID",
                table: "TrainingEquipment");

            migrationBuilder.DropIndex(
                name: "IX_TrainingEquipment_DietID",
                table: "TrainingEquipment");

            migrationBuilder.DropIndex(
                name: "IX_SupplementRoutine_DietId",
                table: "SupplementRoutine");

            migrationBuilder.DropIndex(
                name: "IX_CustomizedRoutine_SupplementId",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "TrainingEquipment");

            migrationBuilder.DropColumn(
                name: "DietID",
                table: "TrainingEquipment");

            migrationBuilder.DropColumn(
                name: "DietId",
                table: "SupplementRoutine");

            migrationBuilder.DropColumn(
                name: "DietWeight",
                table: "Diet");

            migrationBuilder.DropColumn(
                name: "SupplementId",
                table: "CustomizedRoutine");
        }
    }
}
