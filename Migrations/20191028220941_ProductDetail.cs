using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TroydonFitness.Migrations
{
    public partial class ProductDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfTheWeek",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Equipment",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Exercise",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Reps",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Rest",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Sets",
                table: "CustomizedRoutine");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RoutineAdded",
                table: "CustomizedRoutine",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "MuscleGroup",
                table: "CustomizedRoutine",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "DifficultyLevel",
                table: "CustomizedRoutine",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentUsed",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exercise1",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exercise10",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exercise11",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exercise12",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exercise13",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exercise14",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exercise15",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exercise2",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exercise3",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exercise4",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exercise5",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exercise6",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exercise7",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exercise8",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exercise9",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExerciseDetails",
                table: "CustomizedRoutine",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Friday",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Monday",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Saturday",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stretch1",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stretch2",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stretch3",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stretch4",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stretch5",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sunday",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Thursday",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tuesday",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Wednesday",
                table: "CustomizedRoutine",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquipmentUsed",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Exercise1",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Exercise10",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Exercise11",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Exercise12",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Exercise13",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Exercise14",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Exercise15",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Exercise2",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Exercise3",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Exercise4",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Exercise5",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Exercise6",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Exercise7",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Exercise8",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Exercise9",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "ExerciseDetails",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Friday",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Monday",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Saturday",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Stretch1",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Stretch2",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Stretch3",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Stretch4",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Stretch5",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Sunday",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Thursday",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Tuesday",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Wednesday",
                table: "CustomizedRoutine");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RoutineAdded",
                table: "CustomizedRoutine",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MuscleGroup",
                table: "CustomizedRoutine",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DifficultyLevel",
                table: "CustomizedRoutine",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DayOfTheWeek",
                table: "CustomizedRoutine",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Equipment",
                table: "CustomizedRoutine",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Exercise",
                table: "CustomizedRoutine",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Reps",
                table: "CustomizedRoutine",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Rest",
                table: "CustomizedRoutine",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "Sets",
                table: "CustomizedRoutine",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
