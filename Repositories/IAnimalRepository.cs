using AnimalCollectionWithDB.Entities;
using AnimalCollectionWithDB.DTOs;
using System.Collections.Generic;

namespace AnimalCollectionWithDB.Repositories
{
    public interface IAnimalRepository
    {
        List<Animal> GetAll();
        Animal GetByID(int id);
        Animal CreateAnimal(CreateUpdateAnimalDTO createUpdateAnimalDTO);
        Animal UpdateAnimal(CreateUpdateAnimalDTO createUpdateAnimalDTO, int id);
        void DeleteAnimal(int id);
    }
}
