using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TroydonFitnessWebsite.Migrations.Product
{
    public partial class SystemRestore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    HasStock = table.Column<int>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    IsChecked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "PersonalTraining",
                columns: table => new
                {
                    PersonalTrainingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PersonalTrainingName = table.Column<string>(nullable: true),
                    LengthOfRoutine = table.Column<int>(nullable: false),
                    PTSessionType = table.Column<int>(nullable: false),
                    ExperienceLevel = table.Column<int>(nullable: false),
                    PtProductPicture = table.Column<byte[]>(nullable: true),
                    IsFeatured = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalTraining", x => x.PersonalTrainingID);
                    table.ForeignKey(
                        name: "FK_PersonalTraining_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingEquipment",
                columns: table => new
                {
                    TrainingEquipmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(nullable: false),
                    EquipmentName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingEquipment", x => x.TrainingEquipmentID);
                    table.ForeignKey(
                        name: "FK_TrainingEquipment_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diet",
                columns: table => new
                {
                    DietID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalTrainingID = table.Column<int>(nullable: false),
                    OrderID = table.Column<int>(nullable: true),
                    DietName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Allergies = table.Column<string>(nullable: true),
                    PreferredFood = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diet", x => x.DietID);
                    table.ForeignKey(
                        name: "FK_Diet_PersonalTraining_PersonalTrainingID",
                        column: x => x.PersonalTrainingID,
                        principalTable: "PersonalTraining",
                        principalColumn: "PersonalTrainingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingRoutine",
                columns: table => new
                {
                    TrainingRoutineID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalTrainingID = table.Column<int>(nullable: false),
                    RoutineName = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(maxLength: 500, nullable: true),
                    DailyAvailability = table.Column<string>(nullable: true),
                    Monday = table.Column<string>(nullable: true),
                    Tuesday = table.Column<string>(nullable: true),
                    Wednesday = table.Column<string>(nullable: true),
                    Thursday = table.Column<string>(nullable: true),
                    Friday = table.Column<string>(nullable: true),
                    Saturday = table.Column<string>(nullable: true),
                    Sunday = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingRoutine", x => x.TrainingRoutineID);
                    table.ForeignKey(
                        name: "FK_TrainingRoutine_PersonalTraining_PersonalTrainingID",
                        column: x => x.PersonalTrainingID,
                        principalTable: "PersonalTraining",
                        principalColumn: "PersonalTrainingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supplement",
                columns: table => new
                {
                    SupplementID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(nullable: false),
                    DietID = table.Column<int>(nullable: true),
                    SupplementName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplement", x => x.SupplementID);
                    table.ForeignKey(
                        name: "FK_Supplement_Diet_DietID",
                        column: x => x.DietID,
                        principalTable: "Diet",
                        principalColumn: "DietID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Supplement_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingRoutineID = table.Column<int>(nullable: true),
                    DietID = table.Column<int>(nullable: true),
                    SupplementID = table.Column<int>(nullable: true),
                    TrainingEquipmentID = table.Column<int>(nullable: true),
                    ProductID = table.Column<int>(nullable: true),
                    ProductName = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    NumberOfItemsOrdered = table.Column<int>(nullable: false),
                    OrderNumber = table.Column<Guid>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    OrderUpdated = table.Column<DateTime>(nullable: false),
                    PurchaserID = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Order_Diet_DietID",
                        column: x => x.DietID,
                        principalTable: "Diet",
                        principalColumn: "DietID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Supplement_SupplementID",
                        column: x => x.SupplementID,
                        principalTable: "Supplement",
                        principalColumn: "SupplementID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_TrainingEquipment_TrainingEquipmentID",
                        column: x => x.TrainingEquipmentID,
                        principalTable: "TrainingEquipment",
                        principalColumn: "TrainingEquipmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_TrainingRoutine_TrainingRoutineID",
                        column: x => x.TrainingRoutineID,
                        principalTable: "TrainingRoutine",
                        principalColumn: "TrainingRoutineID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    TrainingRoutineID = table.Column<int>(nullable: true),
                    DietID = table.Column<int>(nullable: true),
                    SupplementID = table.Column<int>(nullable: true),
                    TrainingEquipmentID = table.Column<int>(nullable: true),
                    PurchaserID = table.Column<string>(nullable: true),
                    OrderID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    ProductName = table.Column<string>(nullable: true),
                    OrderNumber = table.Column<Guid>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    OrderUpdated = table.Column<DateTime>(nullable: false),
                    CurrentOrderItemNumber = table.Column<int>(nullable: false),
                    PTSessionType = table.Column<int>(nullable: false),
                    LengthOfRoutine = table.Column<int>(nullable: false),
                    ExperienceLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailID);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Diet_DietID",
                        column: x => x.DietID,
                        principalTable: "Diet",
                        principalColumn: "DietID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Supplement_SupplementID",
                        column: x => x.SupplementID,
                        principalTable: "Supplement",
                        principalColumn: "SupplementID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_TrainingEquipment_TrainingEquipmentID",
                        column: x => x.TrainingEquipmentID,
                        principalTable: "TrainingEquipment",
                        principalColumn: "TrainingEquipmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_TrainingRoutine_TrainingRoutineID",
                        column: x => x.TrainingRoutineID,
                        principalTable: "TrainingRoutine",
                        principalColumn: "TrainingRoutineID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingRoutineID = table.Column<int>(nullable: true),
                    DietID = table.Column<int>(nullable: true),
                    SupplementID = table.Column<int>(nullable: true),
                    TrainingEquipmentID = table.Column<int>(nullable: true),
                    PurchaserID = table.Column<string>(nullable: true),
                    OrderID = table.Column<int>(nullable: true),
                    ProductID = table.Column<int>(nullable: true),
                    PersonalTrainingSessionPersonalTrainingID = table.Column<int>(nullable: true),
                    OrderDetailID = table.Column<int>(nullable: true),
                    ProductName = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.CartID);
                    table.ForeignKey(
                        name: "FK_Cart_Diet_DietID",
                        column: x => x.DietID,
                        principalTable: "Diet",
                        principalColumn: "DietID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cart_OrderDetails_OrderDetailID",
                        column: x => x.OrderDetailID,
                        principalTable: "OrderDetails",
                        principalColumn: "OrderDetailID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cart_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cart_PersonalTraining_PersonalTrainingSessionPersonalTrainingID",
                        column: x => x.PersonalTrainingSessionPersonalTrainingID,
                        principalTable: "PersonalTraining",
                        principalColumn: "PersonalTrainingID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cart_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cart_Supplement_SupplementID",
                        column: x => x.SupplementID,
                        principalTable: "Supplement",
                        principalColumn: "SupplementID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cart_TrainingEquipment_TrainingEquipmentID",
                        column: x => x.TrainingEquipmentID,
                        principalTable: "TrainingEquipment",
                        principalColumn: "TrainingEquipmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cart_TrainingRoutine_TrainingRoutineID",
                        column: x => x.TrainingRoutineID,
                        principalTable: "TrainingRoutine",
                        principalColumn: "TrainingRoutineID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_DietID",
                table: "Cart",
                column: "DietID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_OrderDetailID",
                table: "Cart",
                column: "OrderDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_OrderID",
                table: "Cart",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_PersonalTrainingSessionPersonalTrainingID",
                table: "Cart",
                column: "PersonalTrainingSessionPersonalTrainingID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ProductID",
                table: "Cart",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_SupplementID",
                table: "Cart",
                column: "SupplementID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_TrainingEquipmentID",
                table: "Cart",
                column: "TrainingEquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_TrainingRoutineID",
                table: "Cart",
                column: "TrainingRoutineID");

            migrationBuilder.CreateIndex(
                name: "IX_Diet_PersonalTrainingID",
                table: "Diet",
                column: "PersonalTrainingID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_DietID",
                table: "Order",
                column: "DietID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductID",
                table: "Order",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_SupplementID",
                table: "Order",
                column: "SupplementID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_TrainingEquipmentID",
                table: "Order",
                column: "TrainingEquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_TrainingRoutineID",
                table: "Order",
                column: "TrainingRoutineID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_DietID",
                table: "OrderDetails",
                column: "DietID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductID",
                table: "OrderDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_SupplementID",
                table: "OrderDetails",
                column: "SupplementID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_TrainingEquipmentID",
                table: "OrderDetails",
                column: "TrainingEquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_TrainingRoutineID",
                table: "OrderDetails",
                column: "TrainingRoutineID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalTraining_ProductID",
                table: "PersonalTraining",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Supplement_DietID",
                table: "Supplement",
                column: "DietID");

            migrationBuilder.CreateIndex(
                name: "IX_Supplement_ProductID",
                table: "Supplement",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingEquipment_ProductID",
                table: "TrainingEquipment",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingRoutine_PersonalTrainingID",
                table: "TrainingRoutine",
                column: "PersonalTrainingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Supplement");

            migrationBuilder.DropTable(
                name: "TrainingEquipment");

            migrationBuilder.DropTable(
                name: "TrainingRoutine");

            migrationBuilder.DropTable(
                name: "Diet");

            migrationBuilder.DropTable(
                name: "PersonalTraining");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
