﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TroydonFitnessWebsite.Data;

namespace TroydonFitnessWebsite.Migrations.Product
{
    [DbContext(typeof(ProductContext))]
    partial class ProductContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TroydonFitnessWebsite.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DietID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfItemsOrdered")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("OrderNumber")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OrderUpdated")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ProductID")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PurchaserID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SupplementID")
                        .HasColumnType("int");

                    b.Property<int?>("TrainingEquipmentID")
                        .HasColumnType("int");

                    b.Property<int?>("TrainingRoutineID")
                        .HasColumnType("int");

                    b.Property<string>("Zip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderID");

                    b.HasIndex("DietID");

                    b.HasIndex("ProductID");

                    b.HasIndex("SupplementID");

                    b.HasIndex("TrainingEquipmentID");

                    b.HasIndex("TrainingRoutineID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("TroydonFitnessWebsite.Models.Products.Cart", b =>
                {
                    b.Property<int>("CartID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DietID")
                        .HasColumnType("int");

                    b.Property<int?>("OrderDetailID")
                        .HasColumnType("int");

                    b.Property<int?>("OrderID")
                        .HasColumnType("int");

                    b.Property<int?>("PersonalTrainingSessionPersonalTrainingID")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ProductID")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PurchaserID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("SupplementID")
                        .HasColumnType("int");

                    b.Property<int?>("TrainingEquipmentID")
                        .HasColumnType("int");

                    b.Property<int?>("TrainingRoutineID")
                        .HasColumnType("int");

                    b.HasKey("CartID");

                    b.HasIndex("DietID");

                    b.HasIndex("OrderDetailID");

                    b.HasIndex("OrderID");

                    b.HasIndex("PersonalTrainingSessionPersonalTrainingID");

                    b.HasIndex("ProductID");

                    b.HasIndex("SupplementID");

                    b.HasIndex("TrainingEquipmentID");

                    b.HasIndex("TrainingRoutineID");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("TroydonFitnessWebsite.Models.Products.Diet", b =>
                {
                    b.Property<int>("DietID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Allergies")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DietName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("PersonalTrainingID")
                        .HasColumnType("int");

                    b.Property<string>("PreferredFood")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DietID");

                    b.HasIndex("PersonalTrainingID");

                    b.ToTable("Diet");
                });

            modelBuilder.Entity("TroydonFitnessWebsite.Models.Products.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrentOrderItemNumber")
                        .HasColumnType("int");

                    b.Property<int?>("DietID")
                        .HasColumnType("int");

                    b.Property<int>("ExperienceLevel")
                        .HasColumnType("int");

                    b.Property<int>("LengthOfRoutine")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<Guid?>("OrderNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OrderUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("PTSessionType")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PurchaserID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("SupplementID")
                        .HasColumnType("int");

                    b.Property<int?>("TrainingEquipmentID")
                        .HasColumnType("int");

                    b.Property<int?>("TrainingRoutineID")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailID");

                    b.HasIndex("DietID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.HasIndex("SupplementID");

                    b.HasIndex("TrainingEquipmentID");

                    b.HasIndex("TrainingRoutineID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("TroydonFitnessWebsite.Models.Products.PersonalTraining", b =>
                {
                    b.Property<int>("PersonalTrainingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExperienceLevel")
                        .HasColumnType("int");

                    b.Property<bool>("IsFeatured")
                        .HasColumnType("bit");

                    b.Property<int>("LengthOfRoutine")
                        .HasColumnType("int");

                    b.Property<int>("PTSessionType")
                        .HasColumnType("int");

                    b.Property<string>("PersonalTrainingName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<byte[]>("PtProductPicture")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("PersonalTrainingID");

                    b.HasIndex("ProductID");

                    b.ToTable("PersonalTraining");
                });

            modelBuilder.Entity("TroydonFitnessWebsite.Models.Products.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HasStock")
                        .HasColumnType("int");

                    b.Property<bool>("IsChecked")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("TroydonFitnessWebsite.Models.Products.Supplement", b =>
                {
                    b.Property<int>("SupplementID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DietID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<string>("SupplementName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplementID");

                    b.HasIndex("DietID");

                    b.HasIndex("ProductID");

                    b.ToTable("Supplement");
                });

            modelBuilder.Entity("TroydonFitnessWebsite.Models.Products.TrainingEquipment", b =>
                {
                    b.Property<int>("TrainingEquipmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EquipmentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("TrainingEquipmentID");

                    b.HasIndex("ProductID");

                    b.ToTable("TrainingEquipment");
                });

            modelBuilder.Entity("TroydonFitnessWebsite.Models.Products.TrainingRoutine", b =>
                {
                    b.Property<int>("TrainingRoutineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("DailyAvailability")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Friday")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Monday")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonalTrainingID")
                        .HasColumnType("int");

                    b.Property<string>("RoutineName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Saturday")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sunday")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Thursday")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tuesday")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Wednesday")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrainingRoutineID");

                    b.HasIndex("PersonalTrainingID");

                    b.ToTable("TrainingRoutine");
                });

            modelBuilder.Entity("TroydonFitnessWebsite.Models.Order", b =>
                {
                    b.HasOne("TroydonFitnessWebsite.Models.Products.Diet", "Diet")
                        .WithMany("Orders")
                        .HasForeignKey("DietID");

                    b.HasOne("TroydonFitnessWebsite.Models.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID");

                    b.HasOne("TroydonFitnessWebsite.Models.Products.Supplement", "Supplement")
                        .WithMany("Orders")
                        .HasForeignKey("SupplementID");

                    b.HasOne("TroydonFitnessWebsite.Models.Products.TrainingEquipment", "TrainingEquipment")
                        .WithMany("Orders")
                        .HasForeignKey("TrainingEquipmentID");

                    b.HasOne("TroydonFitnessWebsite.Models.Products.TrainingRoutine", "TrainingRoutine")
                        .WithMany("Orders")
                        .HasForeignKey("TrainingRoutineID");
                });

            modelBuilder.Entity("TroydonFitnessWebsite.Models.Products.Cart", b =>
                {
                    b.HasOne("TroydonFitnessWebsite.Models.Products.Diet", "Diet")
                        .WithMany("CartItems")
                        .HasForeignKey("DietID");

                    b.HasOne("TroydonFitnessWebsite.Models.Products.OrderDetail", "OrderDetail")
                        .WithMany()
                        .HasForeignKey("OrderDetailID");

                    b.HasOne("TroydonFitnessWebsite.Models.Order", "Order")
                        .WithMany("CartItems")
                        .HasForeignKey("OrderID");

                    b.HasOne("TroydonFitnessWebsite.Models.Products.PersonalTraining", "PersonalTrainingSession")
                        .WithMany("Cart")
                        .HasForeignKey("PersonalTrainingSessionPersonalTrainingID");

                    b.HasOne("TroydonFitnessWebsite.Models.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID");

                    b.HasOne("TroydonFitnessWebsite.Models.Products.Supplement", "Supplement")
                        .WithMany("CartItems")
                        .HasForeignKey("SupplementID");

                    b.HasOne("TroydonFitnessWebsite.Models.Products.TrainingEquipment", "TrainingEquipment")
                        .WithMany("CartItems")
                        .HasForeignKey("TrainingEquipmentID");

                    b.HasOne("TroydonFitnessWebsite.Models.Products.TrainingRoutine", "TrainingRoutine")
                        .WithMany("CartItems")
                        .HasForeignKey("TrainingRoutineID");
                });

            modelBuilder.Entity("TroydonFitnessWebsite.Models.Products.Diet", b =>
                {
                    b.HasOne("TroydonFitnessWebsite.Models.Products.PersonalTraining", "PersonalTrainingSession")
                        .WithMany("Diets")
                        .HasForeignKey("PersonalTrainingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TroydonFitnessWebsite.Models.Products.OrderDetail", b =>
                {
                    b.HasOne("TroydonFitnessWebsite.Models.Products.Diet", "Diet")
                        .WithMany("OrderDetails")
                        .HasForeignKey("DietID");

                    b.HasOne("TroydonFitnessWebsite.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TroydonFitnessWebsite.Models.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TroydonFitnessWebsite.Models.Products.Supplement", "Supplement")
                        .WithMany("OrderDetails")
                        .HasForeignKey("SupplementID");

                    b.HasOne("TroydonFitnessWebsite.Models.Products.TrainingEquipment", "TrainingEquipment")
                        .WithMany()
                        .HasForeignKey("TrainingEquipmentID");

                    b.HasOne("TroydonFitnessWebsite.Models.Products.TrainingRoutine", "TrainingRoutine")
                        .WithMany("OrderDetails")
                        .HasForeignKey("TrainingRoutineID");
                });

            modelBuilder.Entity("TroydonFitnessWebsite.Models.Products.PersonalTraining", b =>
                {
                    b.HasOne("TroydonFitnessWebsite.Models.Products.Product", "Product")
                        .WithMany("PersonalTrainingSessions")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TroydonFitnessWebsite.Models.Products.Supplement", b =>
                {
                    b.HasOne("TroydonFitnessWebsite.Models.Products.Diet", "Diet")
                        .WithMany("Supplements")
                        .HasForeignKey("DietID");

                    b.HasOne("TroydonFitnessWebsite.Models.Products.Product", "Product")
                        .WithMany("Supplements")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TroydonFitnessWebsite.Models.Products.TrainingEquipment", b =>
                {
                    b.HasOne("TroydonFitnessWebsite.Models.Products.Product", "Product")
                        .WithMany("TrainingEquipmentPurchases")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TroydonFitnessWebsite.Models.Products.TrainingRoutine", b =>
                {
                    b.HasOne("TroydonFitnessWebsite.Models.Products.PersonalTraining", "PersonalTrainingSession")
                        .WithMany("TrainingRoutine")
                        .HasForeignKey("PersonalTrainingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
