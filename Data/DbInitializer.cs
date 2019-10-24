using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TroydonFitness.Models;
using TroydonFitness.Models.ProductModel;
using static TroydonFitness.Models.ProductModel.CustomizedRoutine;

namespace TroydonFitness.Data
{
    public class DbInitializer
    {
        // May need to correct seed statement
        public static void Initialize(ProductContext context) // try changing Initialize to Seed
        {

            // context.Database.EnsureCreated();

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
                    Price=70, Quantity=3, HasStock = Product.Availability.Available, ProductAdded = DateTime.Parse("2019-10-01"),
                    },
                new Product{
                    PersonalTrainingId = 2,
                    Title="Easy Stregth Starter Routine", Description="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=90, Quantity=3, HasStock = Product.Availability.Available, ProductAdded = DateTime.Parse("2019-10-01"),
                    },
                new Product{
                    PersonalTrainingId = 3,
                    Title="Easy Stregth Starter Routine", Description="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=110, Quantity=3, HasStock = Product.Availability.Available, ProductAdded = DateTime.Parse("2019-10-01"),
                    },
                // Hypertrophy routines
                new Product{
                    PersonalTrainingId = 4,
                    Title="Easy Stregth Starter Routine", Description="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=75, Quantity=3, HasStock = Product.Availability.Available, ProductAdded = DateTime.Parse("2019-10-01"),
                    },
                new Product{
                    PersonalTrainingId = 5,
                    Title="Easy Stregth Starter Routine", Description="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=90, Quantity=3, HasStock = Product.Availability.Available, ProductAdded = DateTime.Parse("2019-10-15"),
                    },
                new Product{
                    PersonalTrainingId = 6,
                    Title="Easy Stregth Starter Routine", Description="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=120, Quantity=3, HasStock = Product.Availability.Available, ProductAdded = DateTime.Parse("2019-10-15"),
                    },
                // Endurance routines
                new Product{
                    PersonalTrainingId = 7,
                    Title="Easy Stregth Starter Routine", Description="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=100, Quantity=3, HasStock = Product.Availability.Available, ProductAdded = DateTime.Parse("2019-10-21"),
                    },
                new Product{
                    PersonalTrainingId = 8,
                    Title="Easy Stregth Starter Routine", Description="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=100, Quantity=3, HasStock = Product.Availability.Available, ProductAdded = DateTime.Parse("2019-10-25"),
                    },
                new Product{
                    PersonalTrainingId = 9,
                    Title="Easy Stregth Starter Routine", Description="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=100, Quantity=3, HasStock = Product.Availability.Available, ProductAdded = DateTime.Parse("2019-10-25"),
                    },
            };
            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();

            var routines = new CustomizedRoutine[]
            {
                 // Strength routines
                new CustomizedRoutine{
                   RoutineType = "Easy Stregth Starter Routine", RoutineDescription = "This routine is great for those that are new to the fitness " +
                   "industry and want to increase their strength, max training duration is 30 minutes.",
                    DifficultyLevel = Difficulty.Beginner, RoutineAdded = DateTime.Now, ProductID = 2,
                },

                new CustomizedRoutine{
                   RoutineType = "Strength for the trained", RoutineDescription = "This routine is great for those that have some experience in" +
                   " training and are looking at increasing their strength tier",
                    DifficultyLevel = Difficulty.Intermediate, RoutineAdded = DateTime.Now, ProductID = 3,
                },

                new CustomizedRoutine{
                   RoutineType = "Super Heavy Lifter", RoutineDescription = "This routine is great for those that have a lot of experience" +
                   " and are interested in competing in novice powerlifting some time.",
                    DifficultyLevel = Difficulty.Advanced, RoutineAdded = DateTime.Now, ProductID = 4,
                },
                
                // Hypertrophy routines
                new CustomizedRoutine{
                   RoutineType = "Time to grow muscle", RoutineDescription ="This routine is great for those that are new to the fitness" +
                   " industry and want to increase their muscle level, max training duration is 30 minutes.",
                    DifficultyLevel = Difficulty.Beginner, RoutineAdded = DateTime.Now, ProductID = 5,
                },

                new CustomizedRoutine{
                   RoutineType = "Hydro muscle builder", RoutineDescription = "This routine is great for those that have some experience" +
                   " in training and are looking at increasing their muscle tier.",
                    DifficultyLevel = Difficulty.Intermediate, RoutineAdded = DateTime.Now, ProductID = 6,
                },

                new CustomizedRoutine{
                   RoutineType = "Super Heavy Lifter", RoutineDescription = "This routine is great for those that have a lot of experience" +
                   " and are interested in competing in novice powerlifting some time.",
                    DifficultyLevel = Difficulty.Advanced, RoutineAdded = DateTime.Now, ProductID = 7,
                },

                // Endurance routines
                new CustomizedRoutine{
                   RoutineType = "Long distance runner", RoutineDescription = "This routine is great for those that are new to the fitness " +
                   "industry and want to increase their strength, max training duration is 30 minutes.",
                    DifficultyLevel = Difficulty.Beginner, RoutineAdded = DateTime.Now, ProductID = 8,
                },

                new CustomizedRoutine{
                   RoutineType = "Marathon Endurance", RoutineDescription = "This routine is great for those that have some experience" +
                   " in training and are looking at increasing their endurance tier",
                    DifficultyLevel = Difficulty.Intermediate, RoutineAdded = DateTime.Now, ProductID = 9,
                },

                new CustomizedRoutine{
                   RoutineType = " Super Long Marathon Runner", RoutineDescription = "This routine is great for those that have a lot of experience and" +
                   " are interested in competing in novice  marathon running.",
                    DifficultyLevel = Difficulty.Advanced, RoutineAdded = DateTime.Now, ProductID = 17,
                },
            };

            foreach (CustomizedRoutine c in routines)
            {
                context.CustomizedRoutines.Add(c);
            }
            context.SaveChanges();

        }
    }
}
