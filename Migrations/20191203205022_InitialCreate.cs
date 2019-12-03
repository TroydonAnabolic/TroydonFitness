using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TroydonFitness.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonalTraining",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PTTitle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    WorkoutLength = table.Column<TimeSpan>(nullable: false),
                    PTSessionName = table.Column<int>(nullable: false),
                    ExperienceLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalTraining", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalTrainingId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    ProductAdded = table.Column<DateTime>(nullable: false),
                    HasStock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Product_PersonalTraining_PersonalTrainingId",
                        column: x => x.PersonalTrainingId,
                        principalTable: "PersonalTraining",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomizedRoutine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(nullable: false),
                    RoutineType = table.Column<string>(maxLength: 50, nullable: false),
                    RoutineDescription = table.Column<string>(nullable: false),
                    RoutineAdded = table.Column<DateTime>(nullable: false),
                    DifficultyLevel = table.Column<int>(nullable: true),
                    Monday = table.Column<int>(nullable: true),
                    Tuesday = table.Column<int>(nullable: true),
                    Wednesday = table.Column<int>(nullable: true),
                    Thursday = table.Column<int>(nullable: true),
                    Friday = table.Column<int>(nullable: true),
                    Saturday = table.Column<int>(nullable: true),
                    Sunday = table.Column<int>(nullable: true),
                    Exercise1 = table.Column<int>(nullable: true),
                    Exercise2 = table.Column<int>(nullable: true),
                    Exercise3 = table.Column<int>(nullable: true),
                    Exercise4 = table.Column<int>(nullable: true),
                    Exercise5 = table.Column<int>(nullable: true),
                    Exercise6 = table.Column<int>(nullable: true),
                    Exercise7 = table.Column<int>(nullable: true),
                    Exercise8 = table.Column<int>(nullable: true),
                    Exercise9 = table.Column<int>(nullable: true),
                    Exercise10 = table.Column<int>(nullable: true),
                    Exercise11 = table.Column<int>(nullable: true),
                    Exercise12 = table.Column<int>(nullable: true),
                    Exercise13 = table.Column<int>(nullable: true),
                    Exercise14 = table.Column<int>(nullable: true),
                    Exercise15 = table.Column<int>(nullable: true),
                    Exercise16 = table.Column<int>(nullable: true),
                    Exercise17 = table.Column<int>(nullable: true),
                    Exercise18 = table.Column<int>(nullable: true),
                    Exercise19 = table.Column<int>(nullable: true),
                    Exercise20 = table.Column<int>(nullable: true),
                    Exercise21 = table.Column<int>(nullable: true),
                    Exercise22 = table.Column<int>(nullable: true),
                    Exercise23 = table.Column<int>(nullable: true),
                    Exercise24 = table.Column<int>(nullable: true),
                    Exercise25 = table.Column<int>(nullable: true),
                    Exercise26 = table.Column<int>(nullable: true),
                    Exercise27 = table.Column<int>(nullable: true),
                    Exercise28 = table.Column<int>(nullable: true),
                    Stretch1 = table.Column<int>(nullable: true),
                    Stretch2 = table.Column<int>(nullable: true),
                    Stretch3 = table.Column<int>(nullable: true),
                    Stretch4 = table.Column<int>(nullable: true),
                    Stretch5 = table.Column<int>(nullable: true),
                    MuscleGroup = table.Column<int>(nullable: true),
                    EquipmentUsed = table.Column<int>(nullable: true),
                    WorkoutDuration = table.Column<TimeSpan>(nullable: true),
                    ExerciseDetails = table.Column<string>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomizedRoutine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomizedRoutine_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(nullable: true),
                    DietType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diet_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Supplement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(nullable: true),
                    SupplementAdded = table.Column<DateTime>(nullable: false),
                    SupplementType = table.Column<string>(nullable: true),
                    SupplementAvailability = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplement_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingEquipment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(nullable: true),
                    EquipmentType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingEquipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingEquipment_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupplementRoutine",
                columns: table => new
                {
                    SupplementId = table.Column<int>(nullable: false),
                    CustomizedRoutineId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplementRoutine", x => new { x.SupplementId, x.CustomizedRoutineId });
                    table.ForeignKey(
                        name: "FK_SupplementRoutine_CustomizedRoutine_CustomizedRoutineId",
                        column: x => x.CustomizedRoutineId,
                        principalTable: "CustomizedRoutine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupplementRoutine_Supplement_SupplementId",
                        column: x => x.SupplementId,
                        principalTable: "Supplement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomizedRoutine_ProductID",
                table: "CustomizedRoutine",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Diet_ProductID",
                table: "Diet",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_PersonalTrainingId",
                table: "Product",
                column: "PersonalTrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplement_ProductID",
                table: "Supplement",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplementRoutine_CustomizedRoutineId",
                table: "SupplementRoutine",
                column: "CustomizedRoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingEquipment_ProductID",
                table: "TrainingEquipment",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diet");

            migrationBuilder.DropTable(
                name: "SupplementRoutine");

            migrationBuilder.DropTable(
                name: "TrainingEquipment");

            migrationBuilder.DropTable(
                name: "CustomizedRoutine");

            migrationBuilder.DropTable(
                name: "Supplement");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "PersonalTraining");
        }
    }
}
