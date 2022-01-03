using AnimalCollectionWithDB.Entities;

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
            return _context.Animals.ToList();
        }

        public Animal GetByID(int id)
        {
            Animal animal = _context.Animals.Find(id);
            return animal;
        }

        public Animal CreateAnimal(Animal animal)
        {
            _context.Animals.Add(animal);
            _context.SaveChanges();

            return animal;
        }

        public Animal UpdateAnimal(Animal animal, int id)
        {
            Animal currentAnimal = _context.Animals.FirstOrDefault(item => item.ID == animal.ID);
            if (currentAnimal != null)
            {
                currentAnimal.Name = animal.Name;
                currentAnimal.AnimalTypeID = animal.AnimalTypeID;
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