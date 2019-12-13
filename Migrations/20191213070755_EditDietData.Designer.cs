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
    [Migration("20191213070755_EditDietData")]
    partial class EditDietData
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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DifficultyLevel")
                        .HasColumnType("int");

                    b.Property<int?>("EquipmentUsed")
                        .HasColumnType("int");

                    b.Property<int?>("Exercise1")
                        .HasColumnType("int");

                    b.Property<int?>("Exercise10")
                        .HasColumnType("int");

                    b.Property<int?>("Exercise11")
                        .HasColumnType("int");

                    b.Property<int?>("Exercise12")
                        .HasColumnType("int");

                    b.Property<int?>("Exercise13")
                        .HasColumnType("int");

                    b.Property<int?>("Exercise14")
                        .HasColumnType("int");

                    b.Property<int?>("Exercise15")
                        .HasColumnType("int");

                    b.Property<int?>("Exercise16")
                        .HasColumnType("int");

                    b.Property<int?>("Exercise17")
                        .HasColumnType("int");

                    b.Property<int?>("Exercise18")
                        .HasColumnType("int");

                    b.Property<int?>("Exercise19")
                        .HasColumnType("int");

                    b.Property<int?>("Exercise2")
                        .HasColumnType("int");

                    b.Property<int?>("Exercise20")
                        .HasColumnType("int");

                    b.Property<int?>("Exercise21")
                        .HasColumnType("int");

                    b.Property<int?>("Exercise22")
                        .HasColumnType("int");

                    b.Property<int?>("Exercise23")
                        .HasColumnType("int");

                    b.Property<int?>("Exercise24")
                        .HasColumnType("int");

                    b.Property<int?>("Exercise25")
                        .HasColumnType("int");

                    b.Property<int?>("Exercise26")
                        .HasColumnType("int");

                    b.Property<int?>("Exercise27")
                        .HasColumnType("int");

                    b.Property<int?>("Exercise28")
                        .HasColumnType("int");

                    b.Property<int?>("Exercise3")
                        .HasColumnType("int");

                    b.Property<int?>("Exercise4")
                        .HasColumnType("int");

                    b.Property<int?>("Exercise5")
                        .HasColumnType("int");

                    b.Property<int?>("Exercise6")
                        .HasColumnType("int");

                    b.Property<int?>("Exercise7")
                        .HasColumnType("int");

                    b.Property<int?>("Exercise8")
                        .HasColumnType("int");

                    b.Property<int?>("Exercise9")
                        .HasColumnType("int");

                    b.Property<string>("ExerciseDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Friday")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Monday")
                        .HasColumnType("int");

                    b.Property<int?>("MuscleGroup")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RoutineAdded")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("RoutineDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoutineType")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("Saturday")
                        .HasColumnType("int");

                    b.Property<int?>("Stretch1")
                        .HasColumnType("int");

                    b.Property<int?>("Stretch2")
                        .HasColumnType("int");

                    b.Property<int?>("Stretch3")
                        .HasColumnType("int");

                    b.Property<int?>("Stretch4")
                        .HasColumnType("int");

                    b.Property<int?>("Stretch5")
                        .HasColumnType("int");

                    b.Property<int?>("Sunday")
                        .HasColumnType("int");

                    b.Property<int?>("SupplementId")
                        .HasColumnType("int");

                    b.Property<int?>("Thursday")
                        .HasColumnType("int");

                    b.Property<int?>("Tuesday")
                        .HasColumnType("int");

                    b.Property<int?>("Wednesday")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("WorkoutDuration")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("ProductID");

                    b.HasIndex("SupplementId");

                    b.ToTable("CustomizedRoutine");
                });

            modelBuilder.Entity("TroydonFitness.Models.ProductModel.Diet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DietType")
                        .HasColumnType("int");

                    b.Property<decimal>("DietWeight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductID");

                    b.ToTable("Diet");
                });

            modelBuilder.Entity("TroydonFitness.Models.ProductModel.PersonalTraining", b =>
                {
                    b.Property<int>("Id")
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

                    b.Property<TimeSpan>("WorkoutLength")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("PersonalTraining");
                });

            modelBuilder.Entity("TroydonFitness.Models.ProductModel.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DietID")
                        .HasColumnType("int");

                    b.Property<int>("HasStock")
                        .HasColumnType("int");

                    b.Property<int>("PersonalTrainingId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ProductAdded")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("Title")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ProductID");

                    b.HasIndex("PersonalTrainingId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("TroydonFitness.Models.ProductModel.Supplement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<DateTime>("SupplementAdded")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SupplementAvailability")
                        .HasColumnType("int");

                    b.Property<string>("SupplementType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductID");

                    b.ToTable("Supplement");
                });

            modelBuilder.Entity("TroydonFitness.Models.ProductModel.SupplementRoutine", b =>
                {
                    b.Property<int>("SupplementId")
                        .HasColumnType("int");

                    b.Property<int>("CustomizedRoutineId")
                        .HasColumnType("int");

                    b.Property<int?>("DietId")
                        .HasColumnType("int");

                    b.HasKey("SupplementId", "CustomizedRoutineId");

                    b.HasIndex("CustomizedRoutineId");

                    b.HasIndex("DietId");

                    b.ToTable("SupplementRoutine");
                });

            modelBuilder.Entity("TroydonFitness.Models.ProductModel.TrainingEquipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("DietID")
                        .HasColumnType("int");

                    b.Property<int>("EquipmentType")
                        .HasColumnType("int");

                    b.Property<int?>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DietID")
                        .IsUnique();

                    b.HasIndex("ProductID");

                    b.ToTable("TrainingEquipment");
                });

            modelBuilder.Entity("TroydonFitness.Models.ProductModel.CustomizedRoutine", b =>
                {
                    b.HasOne("TroydonFitness.Models.ProductModel.Product", "Product")
                        .WithMany("CustomizedRoutines")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TroydonFitness.Models.ProductModel.Supplement", null)
                        .WithMany("CustomizedRoutines")
                        .HasForeignKey("SupplementId");
                });

            modelBuilder.Entity("TroydonFitness.Models.ProductModel.Diet", b =>
                {
                    b.HasOne("TroydonFitness.Models.ProductModel.Product", "Product")
                        .WithMany("Diets")
                        .HasForeignKey("ProductID");
                });

            modelBuilder.Entity("TroydonFitness.Models.ProductModel.Product", b =>
                {
                    b.HasOne("TroydonFitness.Models.ProductModel.PersonalTraining", "PersonalTrainingSessions")
                        .WithMany("Products")
                        .HasForeignKey("PersonalTrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TroydonFitness.Models.ProductModel.Supplement", b =>
                {
                    b.HasOne("TroydonFitness.Models.ProductModel.Product", "Product")
                        .WithMany("Supplements")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TroydonFitness.Models.ProductModel.SupplementRoutine", b =>
                {
                    b.HasOne("TroydonFitness.Models.ProductModel.CustomizedRoutine", "CustomizedRoutine")
                        .WithMany("SupplementRoutines")
                        .HasForeignKey("CustomizedRoutineId");

                    b.HasOne("TroydonFitness.Models.ProductModel.Diet", null)
                        .WithMany("SupplementRoutine")
                        .HasForeignKey("DietId");

                    b.HasOne("TroydonFitness.Models.ProductModel.Supplement", "Supplement")
                        .WithMany("SupplementRoutines")
                        .HasForeignKey("SupplementId");
                });

            modelBuilder.Entity("TroydonFitness.Models.ProductModel.TrainingEquipment", b =>
                {
                    b.HasOne("TroydonFitness.Models.ProductModel.Diet", "Diet")
                        .WithOne("TrainingEquipment")
                        .HasForeignKey("TroydonFitness.Models.ProductModel.TrainingEquipment", "DietID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TroydonFitness.Models.ProductModel.Product", "Product")
                        .WithMany("TrainingEquipments")
                        .HasForeignKey("ProductID");
                });
#pragma warning restore 612, 618
        }
    }
}
