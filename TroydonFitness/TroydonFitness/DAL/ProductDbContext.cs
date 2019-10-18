using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;
using TroydonFitness.Models.Products;

namespace TroydonFitness.DAL
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
        : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<CustomizedRoutine> CustomizedRoutines { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Supplement> Supplements { get; set; }
        public DbSet<TrainingEquipment> TrainingEquipments { get; set; }

        public IQueryable<PersonalTraining> PersonalTrainingSessions { get; set; }
        //{
        //    get
        //    {
        //        return new[]
        //        {
        //            // Strength sessions
        //            new PersonalTraining {
        //                Key = "strength",
        //                Title = "Beginner Strength Training",
        //                Description = "This routine is great for those that are new to the fitness industry and want to increase their strength," +
        //                "max training duration is 30 minutes.",
        //                ExperienceLevel = "Beginner",
        //                WorkoutLength = new TimeSpan(0, 30, 00),
        //            },
        //            new PersonalTraining {
        //                Key = "strength",
        //                Title = "Intermediate Strength Training",
        //                Description = "This routine is great for those that have some experience in training and are looking at increasing their strength tier",
        //                ExperienceLevel = "Intermediate",
        //                WorkoutLength = new TimeSpan(0, 45, 00),
        //            },
        //            new PersonalTraining {
        //                Key = "strength",
        //                Title = "Advanced Strength Training",
        //                Description = "This routine is great for those that have a lot of experience and are interested in competing in novice powerlifting some time.",
        //                ExperienceLevel = "Advanced",
        //                WorkoutLength = new TimeSpan(0, 60, 00),
        //            },

        //            // Hypertrophy Sessions
        //            new PersonalTraining {
        //                Key = "hypertrophy",
        //                Title = "Beginner Strength Training",
        //                Description = "This routine is great for those that are new to the fitness industry and want to increase their muscle level," +
        //                "max training duration is 30 minutes.",
        //                ExperienceLevel = "Beginner",
        //                WorkoutLength = new TimeSpan(0, 30, 00),
        //            },
        //            new PersonalTraining {
        //                Key = "hypertrophy",
        //                Title = "Intermediate Hypertrophy Training",
        //                Description = "This routine is great for those that have some experience in training and are looking at increasing their muscle tier",
        //                ExperienceLevel = "Intermediate",
        //                WorkoutLength = new TimeSpan(0, 45, 00),
        //            },
        //            new PersonalTraining {
        //                Key = "hypertrophy",
        //                Title = "Advanced Hypertrophy Training",
        //                Description = "This routine is great for those that have a lot of experience and are interested in competing in novice fitness" +
        //                " model or bodybuilding some time.",
        //                ExperienceLevel = "Advanced",
        //                WorkoutLength = new TimeSpan(0, 60, 00),
        //            }, 

        //            // Endurance Sessions
        //            new PersonalTraining {
        //                Key = "endurance",
        //                Title = "Beginner Endurance Training",
        //                Description = "This routine is great for those that are new to the fitness industry and want to increase their," +
        //                "",
        //                ExperienceLevel = "Beginner",
        //                WorkoutLength = new TimeSpan(0, 30, 00),
        //            },
        //            new PersonalTraining {
        //                Key = "endurance",
        //                Title = "Intermediate Endurance Training",
        //                Description = "This routine is great for those that have some experience in training and are looking at increasing their muscle tier",
        //                ExperienceLevel = "Intermediate",
        //                WorkoutLength = new TimeSpan(0, 45, 00),
        //            },
        //            new PersonalTraining {
        //                Key = "endurance",
        //                Title = "Advanced Endurance Training",
        //                Description = "This routine is great for those that have a lot of experience and are interested in competing in novice fitness" +
        //                " model or bodybuilding some time.",
        //                ExperienceLevel = "Advanced",
        //                WorkoutLength = new TimeSpan(0, 60, 00),
        //            },

        //        }.AsQueryable();
        //    }
        //}



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Define composite key.
            //builder.Entity<Products>()
            //    .HasKey(p => new { p.ProductID});

            builder.Entity<Product>().ToTable("Products");
            builder.Entity<CustomizedRoutine>().ToTable("CustomizedRoutine");
            builder.Entity<Supplement>().ToTable("Supplement");

            // Fluent API to define Entity Relationships
            builder.Entity<Supplement>().HasMany(routine => routine.CustomizedRoutines)
                           .WithOne().HasForeignKey(prod => prod.ProductID);

            builder.Entity<CustomizedRoutine>().HasMany(supps => supps.Supplements)
                            .WithOne().HasForeignKey(prod => prod.ProductID);

            builder.Entity<PersonalTraining>().HasMany(prod => prod.Products);

            // Product to others

            builder.Entity<Product>().HasMany(supps => supps.Supplements);

            builder.Entity<Product>().HasMany(routine => routine.CustomizedRoutines);

            builder.Entity<Product>().HasMany(diet => diet.Diets);

            builder.Entity<Product>().HasMany(equip => equip.TrainingEquipments);

            builder.Entity<Product>().HasOne(PT => PT.PersonalTrainingSessions);

            //builder.Entity<Products>()
            //    .HasOne(p => p.Product)
            //    .WithMany(c => c.CustomizedRoutines)
            //    .HasForeignKey(p => p.Product);

            //builder.Entity<Products>()
            //    .HasOne(p => p.Product)
            //    .WithMany(c => c.TrainingEquipments)
            //    .HasForeignKey(p => p.Product);
        }
    }
}
