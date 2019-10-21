using Microsoft.EntityFrameworkCore.Migrations;

namespace TroydonFitness.Migrations
{
    public partial class ProductLogicUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalTraining_PersonalTraining_PersonalTrainingSessionsPersonalTrainingID",
                table: "PersonalTraining");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_PersonalTraining_PersonalTrainingId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplementRoutine_CustomizedRoutine_CustomizedRoutineId",
                table: "SupplementRoutine");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplementRoutine_Supplement_SupplementId",
                table: "SupplementRoutine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingEquipment",
                table: "TrainingEquipment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supplement",
                table: "Supplement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonalTraining",
                table: "PersonalTraining");

            migrationBuilder.DropIndex(
                name: "IX_PersonalTraining_PersonalTrainingSessionsPersonalTrainingID",
                table: "PersonalTraining");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diet",
                table: "Diet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomizedRoutine",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "TrainingEquipmentID",
                table: "TrainingEquipment");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SupplementRoutine");

            migrationBuilder.DropColumn(
                name: "SupplementID",
                table: "Supplement");

            migrationBuilder.DropColumn(
                name: "CustomizedRoutineID",
                table: "Supplement");

            migrationBuilder.DropColumn(
                name: "PersonalTrainingID",
                table: "PersonalTraining");

            migrationBuilder.DropColumn(
                name: "PersonalTrainingSessionsPersonalTrainingID",
                table: "PersonalTraining");

            migrationBuilder.DropColumn(
                name: "DietID",
                table: "Diet");

            migrationBuilder.DropColumn(
                name: "CustomizedRoutineID",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "SupplementID",
                table: "CustomizedRoutine");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "TrainingEquipment",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TrainingEquipment",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Supplement",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Supplement",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalTrainingId",
                table: "Product",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PersonalTraining",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Diet",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Diet",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "CustomizedRoutine",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CustomizedRoutine",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingEquipment",
                table: "TrainingEquipment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supplement",
                table: "Supplement",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonalTraining",
                table: "PersonalTraining",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diet",
                table: "Diet",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomizedRoutine",
                table: "CustomizedRoutine",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_PersonalTraining_PersonalTrainingId",
                table: "Product",
                column: "PersonalTrainingId",
                principalTable: "PersonalTraining",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplementRoutine_CustomizedRoutine_CustomizedRoutineId",
                table: "SupplementRoutine",
                column: "CustomizedRoutineId",
                principalTable: "CustomizedRoutine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplementRoutine_Supplement_SupplementId",
                table: "SupplementRoutine",
                column: "SupplementId",
                principalTable: "Supplement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_PersonalTraining_PersonalTrainingId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplementRoutine_CustomizedRoutine_CustomizedRoutineId",
                table: "SupplementRoutine");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplementRoutine_Supplement_SupplementId",
                table: "SupplementRoutine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingEquipment",
                table: "TrainingEquipment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supplement",
                table: "Supplement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonalTraining",
                table: "PersonalTraining");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diet",
                table: "Diet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomizedRoutine",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TrainingEquipment");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Supplement");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PersonalTraining");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Diet");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CustomizedRoutine");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "TrainingEquipment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrainingEquipmentID",
                table: "TrainingEquipment",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SupplementRoutine",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Supplement",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplementID",
                table: "Supplement",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CustomizedRoutineID",
                table: "Supplement",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PersonalTrainingId",
                table: "Product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PersonalTrainingID",
                table: "PersonalTraining",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PersonalTrainingSessionsPersonalTrainingID",
                table: "PersonalTraining",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Diet",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DietID",
                table: "Diet",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "CustomizedRoutine",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomizedRoutineID",
                table: "CustomizedRoutine",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "SupplementID",
                table: "CustomizedRoutine",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingEquipment",
                table: "TrainingEquipment",
                column: "TrainingEquipmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supplement",
                table: "Supplement",
                column: "SupplementID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonalTraining",
                table: "PersonalTraining",
                column: "PersonalTrainingID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diet",
                table: "Diet",
                column: "DietID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomizedRoutine",
                table: "CustomizedRoutine",
                column: "CustomizedRoutineID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalTraining_PersonalTrainingSessionsPersonalTrainingID",
                table: "PersonalTraining",
                column: "PersonalTrainingSessionsPersonalTrainingID");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalTraining_PersonalTraining_PersonalTrainingSessionsPersonalTrainingID",
                table: "PersonalTraining",
                column: "PersonalTrainingSessionsPersonalTrainingID",
                principalTable: "PersonalTraining",
                principalColumn: "PersonalTrainingID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_PersonalTraining_PersonalTrainingId",
                table: "Product",
                column: "PersonalTrainingId",
                principalTable: "PersonalTraining",
                principalColumn: "PersonalTrainingID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplementRoutine_CustomizedRoutine_CustomizedRoutineId",
                table: "SupplementRoutine",
                column: "CustomizedRoutineId",
                principalTable: "CustomizedRoutine",
                principalColumn: "CustomizedRoutineID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplementRoutine_Supplement_SupplementId",
                table: "SupplementRoutine",
                column: "SupplementId",
                principalTable: "Supplement",
                principalColumn: "SupplementID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
