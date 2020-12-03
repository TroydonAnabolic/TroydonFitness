using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TroydonFitnessWebsite.Migrations
{
    public partial class addtimeleft : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "TimeLeft",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeLeft",
                table: "AspNetUsers");
        }
    }
}
