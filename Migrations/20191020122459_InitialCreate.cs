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
                    PersonalTrainingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalTrainingSessionsPersonalTrainingID = table.Column<int>(nullable: true),
                    PTTitle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    WorkoutLength = table.Column<TimeSpan>(nullable: false),
                    PTSessionName = table.Column<int>(nullable: false),
                    ExperienceLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalTraining", x => x.PersonalTrainingID);
                    table.ForeignKey(
                        name: "FK_PersonalTraining_PersonalTraining_PersonalTrainingSessionsPersonalTrainingID",
                        column: x => x.PersonalTrainingSessionsPersonalTrainingID,
                        principalTable: "PersonalTraining",
                        principalColumn: "PersonalTrainingID",
                        onDelete: ReferentialAction.SetNull); //changed for .SetRestrict
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalTrainingId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    HasStock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Product_PersonalTraining_PersonalTrainingId",
                        column: x => x.PersonalTrainingId,
                        principalTable: "PersonalTraining",
                        principalColumn: "PersonalTrainingID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CustomizedRoutine",
                columns: table => new
                {
                    CustomizedRoutineID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplementID = table.Column<int>(nullable: true),
                    ProductID = table.Column<int>(nullable: true),
                    RoutineType = table.Column<string>(nullable: true),
                    DifficultyLevel = table.Column<int>(nullable: false),
                    RoutineAdded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomizedRoutine", x => x.CustomizedRoutineID);
                    table.ForeignKey(
                        name: "FK_CustomizedRoutine_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Diet",
                columns: table => new
                {
                    DietID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(nullable: true),
                    DietType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diet", x => x.DietID);
                    table.ForeignKey(
                        name: "FK_Diet_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Supplement",
                columns: table => new
                {
                    SupplementID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomizedRoutineID = table.Column<int>(nullable: true),
                    ProductID = table.Column<int>(nullable: true),
                    SupplementAdded = table.Column<DateTime>(nullable: false),
                    SupplementType = table.Column<string>(nullable: true),
                    SupplementAvailability = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplement", x => x.SupplementID);
                    table.ForeignKey(
                        name: "FK_Supplement_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "TrainingEquipment",
                columns: table => new
                {
                    TrainingEquipmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(nullable: true),
                    EquipmentType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingEquipment", x => x.TrainingEquipmentID);
                    table.ForeignKey(
                        name: "FK_TrainingEquipment_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "SupplementRoutine",
                columns: table => new
                {
                    SupplementId = table.Column<int>(nullable: false),
                    CustomizedRoutineId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplementRoutine", x => new { x.SupplementId, x.CustomizedRoutineId });
                    table.ForeignKey(
                        name: "FK_SupplementRoutine_CustomizedRoutine_CustomizedRoutineId",
                        column: x => x.CustomizedRoutineId,
                        principalTable: "CustomizedRoutine",
                        principalColumn: "CustomizedRoutineID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupplementRoutine_Supplement_SupplementId",
                        column: x => x.SupplementId,
                        principalTable: "Supplement",
                        principalColumn: "SupplementID",
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
                name: "IX_PersonalTraining_PersonalTrainingSessionsPersonalTrainingID",
                table: "PersonalTraining",
                column: "PersonalTrainingSessionsPersonalTrainingID");

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
