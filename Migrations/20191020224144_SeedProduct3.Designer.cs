﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TroydonFitness.Data;

namespace TroydonFitness.Migrations
{
    [DbContext(typeof(ProductContext))]
    [Migration("20191020224144_SeedProduct3")]
    partial class SeedProduct3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TroydonFitness.Models.ProductModel.CustomizedRoutine", b =>
                {
                    b.Property<int>("CustomizedRoutineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DifficultyLevel")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<DateTime>("RoutineAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("RoutineType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SupplementID")
                        .HasColumnType("int");

                    b.HasKey("CustomizedRoutineID");

                    b.HasIndex("ProductID");

                    b.ToTable("CustomizedRoutine");
                });

            modelBuilder.Entity("TroydonFitness.Models.ProductModel.Diet", b =>
                {
                    b.Property<int>("DietID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DietType")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("DietID");

                    b.HasIndex("ProductID");

                    b.ToTable("Diet");
                });

            modelBuilder.Entity("TroydonFitness.Models.ProductModel.PersonalTraining", b =>
                {
                    b.Property<int?>("PersonalTrainingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExperienceLevel")
                        .HasColumnType("int");

                    b.Property<int>("PTSessionName")
                        .HasColumnType("int");

                    b.Property<string>("PTTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonalTrainingSessionsPersonalTrainingID")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("WorkoutLength")
                        .HasColumnType("time");

                    b.HasKey("PersonalTrainingID");

                    b.HasIndex("PersonalTrainingSessionsPersonalTrainingID");

                    b.ToTable("PersonalTraining");
                });

            modelBuilder.Entity("TroydonFitness.Models.ProductModel.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HasStock")
                        .HasColumnType("int");

                    b.Property<int?>("PersonalTrainingId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductID");

                    b.HasIndex("PersonalTrainingId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("TroydonFitness.Models.ProductModel.Supplement", b =>
                {
                    b.Property<int>("SupplementID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomizedRoutineID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<DateTime>("SupplementAdded")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SupplementAvailability")
                        .HasColumnType("int");

                    b.Property<string>("SupplementType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplementID");

                    b.HasIndex("ProductID");

                    b.ToTable("Supplement");
                });

            modelBuilder.Entity("TroydonFitness.Models.ProductModel.SupplementRoutine", b =>
                {
                    b.Property<int>("SupplementId")
                        .HasColumnType("int");

                    b.Property<int>("CustomizedRoutineId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("SupplementId", "CustomizedRoutineId");

                    b.HasIndex("CustomizedRoutineId");

                    b.ToTable("SupplementRoutine");
                });

            modelBuilder.Entity("TroydonFitness.Models.ProductModel.TrainingEquipment", b =>
                {
                    b.Property<int>("TrainingEquipmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EquipmentType")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("TrainingEquipmentID");

                    b.HasIndex("ProductID");

                    b.ToTable("TrainingEquipment");
                });

            modelBuilder.Entity("TroydonFitness.Models.ProductModel.CustomizedRoutine", b =>
                {
                    b.HasOne("TroydonFitness.Models.ProductModel.Product", "Product")
                        .WithMany("CustomizedRoutines")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TroydonFitness.Models.ProductModel.Diet", b =>
                {
                    b.HasOne("TroydonFitness.Models.ProductModel.Product", "Product")
                        .WithMany("Diets")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TroydonFitness.Models.ProductModel.PersonalTraining", b =>
                {
                    b.HasOne("TroydonFitness.Models.ProductModel.PersonalTraining", "PersonalTrainingSessions")
                        .WithMany()
                        .HasForeignKey("PersonalTrainingSessionsPersonalTrainingID");
                });

            modelBuilder.Entity("TroydonFitness.Models.ProductModel.Product", b =>
                {
                    b.HasOne("TroydonFitness.Models.ProductModel.PersonalTraining", "PersonalTrainingSessions")
                        .WithMany("Products")
                        .HasForeignKey("PersonalTrainingId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TroydonFitness.Models.ProductModel.Supplement", b =>
                {
                    b.HasOne("TroydonFitness.Models.ProductModel.Product", "Product")
                        .WithMany("Supplements")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TroydonFitness.Models.ProductModel.SupplementRoutine", b =>
                {
                    b.HasOne("TroydonFitness.Models.ProductModel.CustomizedRoutine", "CustomizedRoutine")
                        .WithMany("Supplements")
                        .HasForeignKey("CustomizedRoutineId");

                    b.HasOne("TroydonFitness.Models.ProductModel.Supplement", "Supplement")
                        .WithMany("CustomizedRoutines")
                        .HasForeignKey("SupplementId");
                });

            modelBuilder.Entity("TroydonFitness.Models.ProductModel.TrainingEquipment", b =>
                {
                    b.HasOne("TroydonFitness.Models.ProductModel.Product", "Product")
                        .WithMany("TrainingEquipments")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
