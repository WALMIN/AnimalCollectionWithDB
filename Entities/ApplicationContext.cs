﻿using Microsoft.EntityFrameworkCore;

namespace AnimalCollectionWithDB.Entities
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalType> AnimalTypes { get; set; }

        private string _connectionString = "server=localhost;database=animalCollection;user=root;password=gerdjan123;";

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(
                _connectionString,
                ServerVersion.AutoDetect(_connectionString));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimalType>().HasData(
                new AnimalType
                {
                    ID = 1,
                    Name = "Mammals"
                },
                new AnimalType
                {
                    ID = 2,
                    Name = "Birds"
                },
                new AnimalType
                {
                    ID = 3,
                    Name = "Reptiles"
                },
                new AnimalType
                {
                    ID = 4,
                    Name = "Amphibians"
                },
                new AnimalType
                {
                    ID = 5,
                    Name = "Invertebrates"
                },
                new AnimalType
                {
                    ID = 6,
                    Name = "Fish"
                }
            );

            modelBuilder.Entity<Animal>().HasData(
                new Animal
                {
                    ID = 1,
                    Name = "Chimpanzee",
                    AnimalTypeID = 1
                },
                new Animal
                {
                    ID = 2,
                    Name = "Bald Eagle",
                    AnimalTypeID = 2
                },
                new Animal
                {
                    ID = 3,
                    Name = "Green Sea Turtle",
                    AnimalTypeID = 3
                },
                new Animal
                {
                    ID = 4,
                    Name = "Golden Poisib Frog",
                    AnimalTypeID = 4
                },
                new Animal
                {
                    ID = 5,
                    Name = "Monarch Butterfly",
                    AnimalTypeID = 5
                },
                new Animal
                {
                    ID = 6,
                    Name = "Atlantic Bluefin Tuna",
                    AnimalTypeID = 6
                }
            );

        }

    }

}