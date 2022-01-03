using AnimalCollectionWithDB.Entities;

namespace AnimalCollectionWithDB.Repositories
{
    public interface IAnimalTypeRepository
    {
        List<AnimalType> GetAll();
        AnimalType GetByID(int id);
        AnimalType CreateAnimalType(AnimalType animalType);
        AnimalType UpdateAnimalType(AnimalType animalType, int id);
        void DeleteAnimalType(int id);
    }
}