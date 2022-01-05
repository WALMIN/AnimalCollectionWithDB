using AnimalCollectionWithDB.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AnimalCollectionWithDB.Repositories
{
    public class AnimalTypeRepository : IAnimalTypeRepository
    {
        private ApplicationContext _context;

        public AnimalTypeRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<AnimalType> GetAll()
        {
            return _context.AnimalTypes.Include(animalType => animalType.Animals).ToList();
        }

        public AnimalType GetByID(int id)
        {
            AnimalType animalType = _context.AnimalTypes.Include(animal => animal.Animals).SingleOrDefault(animalType => animalType.ID == id);
            return animalType;
        }

        public AnimalType CreateAnimalType(AnimalType animalType)
        {
            _context.AnimalTypes.Add(animalType);
            _context.SaveChanges();

            return animalType;
        }

        public AnimalType UpdateAnimalType(AnimalType animalType, int id)
        {
            AnimalType currentAnimalType = _context.AnimalTypes.FirstOrDefault(item => item.ID == id);
            if (currentAnimalType != null)
            {
                currentAnimalType.Name = animalType.Name;
            }

            _context.SaveChanges();
            return currentAnimalType;
        }


        public void DeleteAnimalType(int id)
        {
            _context.AnimalTypes.Remove(GetByID(id));
            _context.SaveChanges();
        }

    }

}