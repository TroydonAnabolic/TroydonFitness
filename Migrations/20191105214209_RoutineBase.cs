using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TroydonFitness.Migrations
{
    public partial class RoutineBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "WorkoutDuration",
                table: "CustomizedRoutine",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RoutineAdded",
                table: "CustomizedRoutine",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MuscleGroup",
                table: "CustomizedRoutine",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Exercise16",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exercise17",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exercise18",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exercise19",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exercise20",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exercise21",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exercise22",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exercise23",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exercise24",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exercise25",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exercise26",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exercise27",
                table: "CustomizedRoutine",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exercise28",
                table: "CustomizedRoutine",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Exercise16",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Exercise17",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Exercise18",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Exercise19",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Exercise20",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Exercise21",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Exercise22",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Exercise23",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Exercise24",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Exercise25",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Exercise26",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Exercise27",
                table: "CustomizedRoutine");

            migrationBuilder.DropColumn(
                name: "Exercise28",
                table: "CustomizedRoutine");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "WorkoutDuration",
                table: "CustomizedRoutine",
                type: "time",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RoutineAdded",
                table: "CustomizedRoutine",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "MuscleGroup",
                table: "CustomizedRoutine",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
