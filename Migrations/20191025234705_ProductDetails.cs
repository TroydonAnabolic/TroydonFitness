using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TroydonFitness.Migrations
{
    public partial class ProductDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Product",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Product",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RoutineType",
                table: "CustomizedRoutine",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RoutineDescription",
                table: "CustomizedRoutine",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DayOfTheWeek",
                table: "CustomizedRoutine",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Equipment",
                table: "CustomizedRoutine",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Exercise",
                table: "CustomizedRoutine",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MuscleGroup",
                table: "CustomizedRoutine",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Reps",
                table: "CustomizedRoutine",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Rest",
                table: "CustomizedRoutine",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "Sets",
                table: "CustomizedRoutine",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "WorkoutDuration",
                table: "CustomizedRoutine",
                nullable: true,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));


        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "ImagePath",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "MuscleGroup",
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

            migrationBuilder.DropColumn(
                name: "WorkoutDuration",
                table: "CustomizedRoutine");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "RoutineType",
                table: "CustomizedRoutine",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "RoutineDescription",
                table: "CustomizedRoutine",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
