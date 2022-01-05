using AnimalCollectionWithDB.Entities;
using AnimalCollectionWithDB.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AnimalCollectionWithDB.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private ApplicationContext _context;

        public AnimalRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<Animal> GetAll()
        {
            return _context.Animals.Include(animal => animal.AnimalType).ToList();
        }

        public Animal GetByID(int id)
        {
            Animal animal = _context.Animals.Include(animal => animal.AnimalType).SingleOrDefault(animal => animal.ID == id);
            return animal;
        }

        public Animal CreateAnimal(CreateUpdateAnimalDTO createUpdateAnimalDTO)
        {
            Animal animal = new Animal();
            animal.AnimalTypeID = createUpdateAnimalDTO.AnimalTypeID;
            animal.Name = createUpdateAnimalDTO.Name;

            _context.Animals.Add(animal);
            _context.SaveChanges();

            return animal;
        }

        public Animal UpdateAnimal(CreateUpdateAnimalDTO createUpdateAnimalDTO, int id)
        {
            Animal currentAnimal = _context.Animals.FirstOrDefault(item => item.ID == id);
            if (currentAnimal != null)
            {
                currentAnimal.Name = createUpdateAnimalDTO.Name;
                currentAnimal.AnimalTypeID = createUpdateAnimalDTO.AnimalTypeID;
            }

            _context.SaveChanges();
            return currentAnimal;
        }


        public void DeleteAnimal(int id)
        {
            _context.Animals.Remove(GetByID(id));
            _context.SaveChanges();
        }
    }
}