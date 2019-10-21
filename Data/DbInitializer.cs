﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TroydonFitness.Models.ProductModel;

namespace TroydonFitness.Data
{
    public class DbInitializer
    {
        // May need to correct seed statement
        public static void Initialize(ProductContext context) // try changing Initialize to Seed
        {
            // context.Database.EnsureDeleted(); //may need to add to drop database first to add new schema

            context.Database.EnsureCreated();

            // Look for any CustomizedRoutines.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            var ptSessions = new PersonalTraining[]
{
                    // Strength Sessions
                    new PersonalTraining {
                        PTTitle = "Easy Stregth Starter Routine", PTSessionName = PersonalTraining.SessionType.Strength, ExperienceLevel = PersonalTraining.Difficulty.Beginner,
                        Description = "This routine is great for those that are new to the fitness industry and want to increase their strength," +
                        "max training duration is 30 minutes.",
                        WorkoutLength = new TimeSpan(0, 30, 00),
                    },
                    new PersonalTraining {
                        PTTitle = "Strength for the trained", PTSessionName = PersonalTraining.SessionType.Strength,ExperienceLevel = PersonalTraining.Difficulty.Intermediate,
                        Description = "This routine is great for those that have some experience in training and are looking at increasing their strength tier",
                        WorkoutLength = new TimeSpan(0, 45, 00),
                    },
                    new PersonalTraining {
                        PTTitle = "Super Heavy Lifter", PTSessionName = PersonalTraining.SessionType.Strength, ExperienceLevel = PersonalTraining.Difficulty.Advanced,
                        Description = "This routine is great for those that have a lot of experience and are interested in competing in novice powerlifting some time.",
                        WorkoutLength = new TimeSpan(0, 60, 00),
                    },

                    // Hypertrophy Sessions
                    new PersonalTraining {
                        PTTitle = "Time to grow muscle", PTSessionName = PersonalTraining.SessionType.Hypertrophy, ExperienceLevel = PersonalTraining.Difficulty.Beginner,
                        Description = "This routine is great for those that are new to the fitness industry and want to increase their muscle level," +
                        "max training duration is 30 minutes.",
                        WorkoutLength = new TimeSpan(0, 30, 00),
                    },
                    new PersonalTraining {
                        PTTitle = "Hydro muscle builder", PTSessionName = PersonalTraining.SessionType.Hypertrophy, ExperienceLevel = PersonalTraining.Difficulty.Intermediate,
                        Description = "This routine is great for those that have some experience in training and are looking at increasing their muscle tier",
                        WorkoutLength = new TimeSpan(0, 45, 00),
                    },
                    new PersonalTraining {
                        PTTitle = "Super muscle bodybuilding", PTSessionName = PersonalTraining.SessionType.Hypertrophy,
                        ExperienceLevel = PersonalTraining.Difficulty.Advanced,
                        Description = "This routine is great for those that have a lot of experience and are interested in competing in novice fitness" +
                        " model or bodybuilding some time.",
                        WorkoutLength = new TimeSpan(0, 60, 00),

                    },

                    // Endurance Sessions
                    new PersonalTraining {
                        PTTitle = "Runner Starter", PTSessionName = PersonalTraining.SessionType.Endurance,
                        ExperienceLevel = PersonalTraining.Difficulty.Beginner,
                        Description = "This routine is great for those that are new to the running," +
                        "",
                        WorkoutLength = new TimeSpan(0, 30, 00),
                    },
                    new PersonalTraining {
                        PTTitle = "Long distance runner", PTSessionName = PersonalTraining.SessionType.Endurance,
                        ExperienceLevel = PersonalTraining.Difficulty.Intermediate,
                        Description = "This routine is great for those that have some experience in training and are looking at increasing their endurance tier",
                        WorkoutLength = new TimeSpan(0, 45, 00),
                    },
                    new PersonalTraining {
                        PTTitle = "Marathon Endurance", PTSessionName = PersonalTraining.SessionType.Endurance,
                        ExperienceLevel = PersonalTraining.Difficulty.Advanced,
                        Description = "This routine is great for those that have a lot of experience and are interested in being highly trained with long distance" +
                        " model or bodybuilding some time.",
                        WorkoutLength = new TimeSpan(0, 60, 00),
                    },

                    new PersonalTraining {
                        PTTitle = "Super muscle bodybuilding", PTSessionName = PersonalTraining.SessionType.Hypertrophy,
                        ExperienceLevel = PersonalTraining.Difficulty.Advanced,
                        Description = "This routine is great for those that have a lot of experience and are interested in competing in novice fitness" +
                        " model or bodybuilding some time.",
                        WorkoutLength = new TimeSpan(0, 60, 00),

                    },
};
            foreach (PersonalTraining pt in ptSessions)
            {
                context.PersonalTrainingSessions.Add(pt);
            }
            context.SaveChanges();

            var products = new Product[]
            {
                // Strength routines
                new Product{
                    PersonalTrainingId = 1,
                    Title="Easy Stregth Starter Routine", Description="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=70, Quantity=3, HasStock = Product.Availability.Available,
                    },
                new Product{
                    PersonalTrainingId = 2,
                    Title="Easy Stregth Starter Routine", Description="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=90, Quantity=3, HasStock = Product.Availability.Available,
                    },
                new Product{
                    PersonalTrainingId = 3,
                    Title="Easy Stregth Starter Routine", Description="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=110, Quantity=3, HasStock = Product.Availability.Available,
                    },
                // Hypertrophy routines
                new Product{
                    PersonalTrainingId = 4,
                    Title="Easy Stregth Starter Routine", Description="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=75, Quantity=3, HasStock = Product.Availability.Available,
                    },
                new Product{
                    PersonalTrainingId = 5,
                    Title="Easy Stregth Starter Routine", Description="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=90, Quantity=3, HasStock = Product.Availability.Available,
                    },
                new Product{
                    PersonalTrainingId = 6,
                    Title="Easy Stregth Starter Routine", Description="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=120, Quantity=3, HasStock = Product.Availability.Available,
                    },
                // Endurance routines
                new Product{
                    PersonalTrainingId = 7,
                    Title="Easy Stregth Starter Routine", Description="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=100, Quantity=3, HasStock = Product.Availability.Available,
                    },
                new Product{
                    PersonalTrainingId = 8,
                    Title="Easy Stregth Starter Routine", Description="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=100, Quantity=3, HasStock = Product.Availability.Available,
                    },
                new Product{
                    PersonalTrainingId = 9,
                    Title="Easy Stregth Starter Routine", Description="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=100, Quantity=3, HasStock = Product.Availability.Available,
                    },
            };
            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();


        }
    }
}