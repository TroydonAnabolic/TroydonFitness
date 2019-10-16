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

        public DbSet<PersonalTraining> OnlinePersonalTrainingSessions { get; set; }
        public DbSet<CustomizedRoutine> CustomizedRoutines { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Supplement> Supplements { get; set; }
        public DbSet<TrainingEquipment> TrainingEquipments { get; set; }

        public IQueryable<PersonalTraining> PersonalTrainingSessions
        {
            get
            {
                return new[]
                {
                    // Strength sessions
                    new PersonalTraining {
                        Key = "strength",
                        Title = "Beginner Strength Training",
                        Description = "This routine is great for those that are new to the fitness industry and want to increase their strength," +
                        "max training duration is 30 minutes.",
                        ExperienceLevel = "Beginner",
                        WorkoutLength = new TimeSpan(0, 30, 00),
                    },
                    new PersonalTraining {
                        Key = "strength",
                        Title = "Intermediate Strength Training",
                        Description = "This routine is great for those that have some experience in training and are looking at increasing their strength tier",
                        ExperienceLevel = "Intermediate",
                        WorkoutLength = new TimeSpan(0, 45, 00),
                    },
                    new PersonalTraining {
                        Key = "strength",
                        Title = "Advanced Strength Training",
                        Description = "This routine is great for those that have a lot of experience and are interested in competing in novice powerlifting some time.",
                        ExperienceLevel = "Advanced",
                        WorkoutLength = new TimeSpan(0, 60, 00),
                    },

                    // Hypertrophy Sessions
                    new PersonalTraining {
                        Key = "hypertrophy",
                        Title = "Beginner Strength Training",
                        Description = "This routine is great for those that are new to the fitness industry and want to increase their muscle level," +
                        "max training duration is 30 minutes.",
                        ExperienceLevel = "Beginner",
                        WorkoutLength = new TimeSpan(0, 30, 00),
                    },
                    new PersonalTraining {
                        Key = "hypertrophy",
                        Title = "Intermediate Hypertrophy Training",
                        Description = "This routine is great for those that have some experience in training and are looking at increasing their muscle tier",
                        ExperienceLevel = "Intermediate",
                        WorkoutLength = new TimeSpan(0, 45, 00),
                    },
                    new PersonalTraining {
                        Key = "hypertrophy",
                        Title = "Advanced Hypertrophy Training",
                        Description = "This routine is great for those that have a lot of experience and are interested in competing in novice fitness" +
                        " model or bodybuilding some time.",
                        ExperienceLevel = "Advanced",
                        WorkoutLength = new TimeSpan(0, 60, 00),
                    }, 

                    // Endurance Sessions
                    new PersonalTraining {
                        Key = "endurance",
                        Title = "Beginner Endurance Training",
                        Description = "This routine is great for those that are new to the fitness industry and want to increase their," +
                        "",
                        ExperienceLevel = "Beginner",
                        WorkoutLength = new TimeSpan(0, 30, 00),
                    },
                    new PersonalTraining {
                        Key = "endurance",
                        Title = "Intermediate Endurance Training",
                        Description = "This routine is great for those that have some experience in training and are looking at increasing their muscle tier",
                        ExperienceLevel = "Intermediate",
                        WorkoutLength = new TimeSpan(0, 45, 00),
                    },
                    new PersonalTraining {
                        Key = "endurance",
                        Title = "Advanced Endurance Training",
                        Description = "This routine is great for those that have a lot of experience and are interested in competing in novice fitness" +
                        " model or bodybuilding some time.",
                        ExperienceLevel = "Advanced",
                        WorkoutLength = new TimeSpan(0, 60, 00),
                    },

                }.AsQueryable();
            }
        }

        public DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Define composite key.
            builder.Entity<Products>()
                .HasKey(p => new { p.ProductID});

            //builder.Entity<Products>()
            //    .HasOne(p => p.Product)
            //    .WithMany(c => c.PersonalTrainingSessions)
            //    .HasForeignKey(p => p.Product);

            //builder.Entity<Products>()
            //    .HasOne(p => p.Product)
            //    .WithMany(c => c.Diets)
            //    .HasForeignKey(p => p.Product);

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
