using AnimalCollectionWithDB.Entities;

namespace AnimalCollectionWithDB.Repositories
{
    public interface IAnimalRepository
    {
        List<Animal> GetAll();
        Animal GetByID(int id);
        Animal CreateAnimal(Animal animal);
        Animal UpdateAnimal(Animal animal, int id);
        void DeleteAnimal(int id);
    }
}
